`
// Startup.cs: usage
public void ConfigureServices(IServiceCollection services)
{
	// ...
	// This is what the application will use when directly asking for an ISubdependency
	services.AddSingleton<ISubdependency, SubdependencyZ>();
	// This is what we will have RootA and RootB use below
	services.AddSingleton<SubdependencyA>();
	services.AddSingleton<SubdependencyB>();
	services.AddRootA(options => options.UseSubdependency<SubdependencyA>());
	services.AddRootB(options => options.UseSubdependency<SubdependencyB>());
	// ...
}
// RootAExtensions.cs: implementation
public static IServiceCollection AddRootA(this IServiceCollection services, Action<Options> options)
{
	var optionsObject = new Options();
	options(optionsObject); // Let the user's action manipulate the options object
	// Resolve the chosen subdependency at construction time
	var subdependencyType = optionsObject.SubdependencyType;
	services.AddSingleton<IRootA>(serviceProvider =>
		new RootA(serviceProvider.GetRequiredService(subdependencyType)));
	return services;
}
public sealed class Options
{
	public IServiceCollection Services { get; }
	internal Type SubdependencyType { get; set; } = typeof(ISubdependency); // Interface by default
	public Options(IServiceCollection services)
	{
		this.Services = services;
	}
}
// Instructs the library to use the given subdependency
// By default, whatever is registered as ISubdependency is used
public static Options UseSubdependency<TSubdependency>(this Options options)
	where TSubdependency : class, ISubdependency
{
	options.SubdependencyType = typeof(TSubdependency);
	return options;
}
`
First, the user registers anything related to the subdependency. In this example, I have considered the case where the application also uses the subdependency directly, and the direct usage calls for another implementation than the usage by library RootA, which in turn calls for another implementation than RootB.
After registering all this (or before - technically the order doesn't matter), the user registers the high-level dependencies, RootA and RootB. Their options allow the user to specify the subdependency type to use.
Looking at the implementation, you can see that we use the *factory-based overload* of `AddSingleton`, which lets us ask the service provider for any subdependencies at construction time.
The implementation also initializes the type to use to `typeof(ISubdependency)`. If the user were to ignore the `UseSubdependency` method, that would be used:
    services.AddRootA(options => { }); // Will default to asking for an `ISubdependency`
If the user fails to register an implementation for `ISubdependency`, the get the usual exception for that.
---
Note that we never allow the user to _register_ a thing in a nested fashion. That would be confusing: it would _look_ like the registration is only for the thing that wraps it, but since the container is a flat collection, it is _actually_ a global registration.
Instead, we only allow the user to _refer_ to something that they explicitly register elsewhere. This way, no confusion is introduced.
