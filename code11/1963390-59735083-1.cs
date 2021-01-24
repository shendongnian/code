    var serviceCollection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
    serviceCollection.AddEntityFrameworkSqlServer().AddDbContext<Context>();
    var serviceProvider = serviceCollection.BuildServiceProvider();
    var validator = serviceProvider.GetService<IModelValidator>();
    var context = serviceProvider.GetService<Context>();
    
    validator.Validate(context.Model); 
