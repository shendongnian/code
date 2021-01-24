class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }
}
For the configuration you can just use the built in optionsBuilder-action (place inside the `ConfigureServices` method):
services.AddEntityFrameworkSqlServer()
    .AddDbContext(new Action<DbContextOptionsBuilder>(optionsBuilder =>
        optionsBuilder.UseSqlServer((Configuration.GetSection("DBConfiguration") as DBConfiguration).ConnectionString))
    );
Currently the way you get the configuration can definitely be improved. For example you could do something like this:
var DBConfig = Configuration.GetSection("DBConfiguration") as DBConfiguration;
services.AddSingleton(DBConfig);    // <- now you can inject that if you want but it's not necessary
// now we don't need to get the config here
services.AddEntityFrameworkSqlServer()
    .AddDbContext(new Action<DbContextOptionsBuilder>(optionsBuilder =>
        optionsBuilder.UseSqlServer(DBConfig.ConnectionString))
    );
There are some other things you might want to improve like better naming for `DBContext` and not overriding members you don't have a specific implementation for (like you did with `OnModelCreating`).  
Also for a next time you should include all the classes that aren't part of some sort of public API like your `DBConfiguration` class.
