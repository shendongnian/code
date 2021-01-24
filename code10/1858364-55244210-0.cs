 c#
var reg = Lifestyle.Scoped.CreateRegistration(() =>
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<EntityDbContext>().UseInMemoryDatabase("Snoogans");
        return new EntityDbContext(optionsBuilder.Options);
    },
    container);
container.AddRegistration<IUnitOfWork>(reg);
container.AddRegistration<IReadEntities>(reg);
container.AddRegistration<IWriteEntities>(reg);
In case you chose to cross-wire your DbContext from the .NET Core configuration system, your configuration would look as follows:
 c#
// Add to the built-in ServiceCollection
services.AddDbContext<EntityDbContext>(options => options.UseInMemoryDatabase("Snoogans"));
// Cross-wire in Simple Injector
container.CrossWire<EntityDbContext>(app);
// Pull that registration out of Simple Injector and use it for the interface registrations
var reg = container.GetRegistration(typeof(EntityDbContext)).Registration;
// Same as before
container.AddRegistration<IUnitOfWork>(reg);
container.AddRegistration<IReadEntities>(reg);
container.AddRegistration<IWriteEntities>(reg);
If you wouldn't be using Simple Injector, but purely .NET Core's built-in DI Container, the registration would look as follows:
 c#
services.AddDbContext<EntityDbContext>(options => options.UseInMemoryDatabase("Snoogans"));
services.AddScoped<IUnitOfWork>(c => c.GetRequiredService<EntityDbContext>());
services.AddScoped<IReadEntities>(c => c.GetRequiredService<EntityDbContext>());
services.AddScoped<IWriteEntities>(c => c.GetRequiredService<EntityDbContext>());
