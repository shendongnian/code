class IntegrationConfig
{
    public int Timeout { get; set; }
    public string Name { get; set; }
}
Then you need to add this config to the DI-system: 
services.AddSingleton(new IntegrationConfig
{
    Timeout = 1234,
    Name = "Integration name"
});
In the class `IntegrationService` you need to add a constructor which takes an object of the config:
public IntegrationService(IntegrationConfig config)
{
    // setup with config or simply store config
}
That's basically all you need. It's not the prettiest solution in my opinion and in `.net core 3` 
you can simply use a factory func to add the HostedService but I think something like this is the best choice 
if you're on `.net core 2.2` or below.
EDIT:  
In the comments Kirk Larkin mentions this:
 > You can emulate the overload. It's just a wrapper around AddTransient<IHostedService, TWhatever>(), which of course does support the factory func approach.
For this you might want to look at the current overload which is accessable [here](https://github.com/aspnet/Extensions/blob/master/src/Hosting/Abstractions/src/ServiceCollectionHostedServiceExtensions.cs):
/// <summary>
/// Add an <see cref="IHostedService"/> registration for the given type.
/// </summary>
/// <typeparam name="THostedService">An <see cref="IHostedService"/> to register.</typeparam>
/// <param name="services">The <see cref="IServiceCollection"/> to register with.</param>
/// <param name="implementationFactory">A factory to create new instances of the service implementation.</param>
/// <returns>The original <see cref="IServiceCollection"/>.</returns>
public static IServiceCollection AddHostedService<THostedService>(this IServiceCollection services, Func<IServiceProvider, THostedService> implementationFactory)
    where THostedService : class, IHostedService
{
    services.TryAddEnumerable(ServiceDescriptor.Singleton<IHostedService>(implementationFactory));
    return services;
}
Note that the [last commit that changed this file](https://github.com/aspnet/Extensions/commit/6e92fcad99b6a6e882ac8dc5ad817b558f603597) was on June 3rd and is tagged for preview6 and preview7 of .net core 3. Because I've never heard of `TryAddEnumerable` and am no microsoft employee, I don't know if you can directly translate that.  
Just from looking at the [current implementation of `AddTransient`](https://github.com/aspnet/Extensions/blob/master/src/DependencyInjection/DI.Abstractions/src/ServiceCollectionServiceExtensions.cs) and going down the rabbit hole a few files more, I sadly can't draw the lines well enough to be able to give you the exact functionality you're currently able to get with `.net core 3`.  
The workaround I gave still works and seems acceptable depending on the situation.
