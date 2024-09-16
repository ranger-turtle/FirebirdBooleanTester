using FirebirdBooleanTester.Model;
using LinqToDB;

string path = "<replace it with path to LOCAL.FDB after unpacking";
string connStr = $"User=SYSDBA;Password=masterkey;Database={path};DataSource=localhost;Charset=utf8;Role=;";
var firebirdConnectionBuidler = new DataOptions<TestDb>(new DataOptions().UseFirebird(connStr));
using TestDb dbContext = new(firebirdConnectionBuidler);

await dbContext.BeginTransactionAsync();
await dbContext.Tests.InsertAsync(
    () => new()
    {
        Id = 1,
        Bool = true
    }
    );
await dbContext.CommitTransactionAsync();
