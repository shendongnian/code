public class BloggingContext : DbContext
{
    public BloggingContext()
    { }
    public BloggingContext(DbContextOptions<BloggingContext> options)
        : base(options)
    { }
    ...
}
Using one provider or another is as simple as creating the options and calling the constructor.
**In-Memory provider**
The in-memory provider is essentially a dictionary, so it can't cover complex query scenarios. It's easier to setup and use though.
    var options = new DbContextOptionsBuilder<BloggingContext>()
        .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
        .Options;
    // Run the test against one instance of the context
    using (var context = new BloggingContext(options))
    {
        var service = new BlogService(context);
        service.Add("https://example.com");
        context.SaveChanges();
    }
**SQLite in-memory provider**
Using the SQLite provider is almost the same. An in-memory database is created and then the code is essentially the same as before. When the connection closes, the database and the data in it are gone.
    using(var connection = new SqliteConnection("DataSource=:memory:"))
    {
        connection.Open();
        var options = new DbContextOptionsBuilder<BloggingContext>()
                    .UseSqlite(connection)
                    .Options;
        // Create the schema in the database
        using (var context = new BloggingContext(options))
        {
                context.Database.EnsureCreated();
        }
        // Run the test against one instance of the context
        using (var context = new BloggingContext(options))
        {
            var service = new BlogService(context);
            service.Add("https://example.com");
            context.SaveChanges();
        }
    }
