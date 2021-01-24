public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<BloggingContext>(options => options.UseSqlite("Data Source=blog.db"));
}
However, yours would look more like:
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<UsersContext>(options => options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;Database=Users; Trusted_Connection=True;"));
}
To give a bit more information, this is telling Asp.net how to resolve the class in which you are specifying in the constructor of the Controller.  For more information search for the topic of Dependency Injection or Inversion of Control (IoC). These are the techniques being used to achieve this functionality.
