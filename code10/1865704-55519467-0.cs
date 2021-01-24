json
{
  ...
  "ConnectionStrings": [
    {
      "Name": "ConnectionString1",
      "Value":  "some value"
    },
    {
      "Name": "ConnectionString1",
      "Value": "some value"
    }
  ]
}
 and map them to some class using [Options pattern][1]:
csharp
public class ConnectionStringOptions
{
    public ConnectionString[] ConnectionStrings { get; set; }
}
charp
public class ConnectionString
{
    public string Name { get; set; }
    public string Value { get; set; }
}
And then, you can have an interface like this one:
csharp
public interface IDatabaseProvider
{
    IEnumerable<Database> GetDatabases();
    Database GetDatabase(string name);
}
with the implementation like this
csharp
public class DatabaseProvider : IDatabaseProvider
{
    private readonly ConnectionStringOptions _options;
    public DatabaseProvider(IOptions<ConnectionStringOptions> optionsAccessor)
    {
        this._options = optionsAccessor.Value;
    }
    public IEnumerable<Database> GetDatabases()
    {
        foreach (ConnectionString connectionString in this._options.ConnectionStrings)
            yield return new SqlDatabase(connectionString.Value);
    }
    public Database GetDatabase(string name)
    {
        string connectionString = this._options.ConnectionStrings.SingleOrDefault(x => x.Name == name).Value;
        return new SqlDatabase(connectionString);
    }
}
Now you just register the `IDatabaseProvider`:
csharp
serviceCollection.AddTransient<IDatabaseProvider, DatabaseProvider>()
and inject it in your services as needed. E.g:
csharp
public class StudentApp
{
    private readonly IEnumerable<Database> _databases;
    public StudentApp(IStudentDataAccess dataAccess, IDatabaseProvider databasesProvider)
    {
        //Or get just the one you want by name
        this._databases = databasesProvider.GetDatabases();
        // ...
    }
    // ...
}
  [1]: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options
