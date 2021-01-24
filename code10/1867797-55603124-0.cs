public class Tests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly DbContextOptions _options;
    public Tests()
    {
        _connection = new SqliteConnection("datasource=:memory:");
        _connection.Open();
        _options = new DbContextOptionsBuilder()
            .UseSqlite(_connection)
            .Options;
        using (var context = new MyContext(_options))
            context.Database.EnsureCreated();
    }
    public void Dispose()
    {
        _connection.Close();
    }
    [Fact]
    public void Test()
    {
        using (var context = new MyContext(_options))
        {
            // use in memory database
            context.ControlGroup ...
        }
    } 
}
