`
// RootA's options object has a fluent extension method to register the subdependency
// This registration will be used ONLY for RootA
public static RootAOptions AddSubdependency<TImplementation>(this RootAOptions options)
    where TImplementation : ISubdependency
{
    // Insert the desired dependency, so that we have a way to resolve it.
    // Register it at index 0, so that potential global registrations stay leading.
    // If we ask for all registered services, we can take the first one.
    // Register it as itself rather than as the interface.
    // This makes it less likely to have a global effect.
    // Also, if RootB registered the same type, we would use either of the identical two.
    options.Services.Insert(0,
        new ServiceDescriptor(typeof(TImplementation), typeof(TImplementation), ServiceLifetime.Singleton));
    // Insert a null-resolver right after it.
    // If the user has not made any other registration, but DOES ask for an instance elsewhere...
    // ...then they will get null, as if nothing was registered, throwing if they'd required it.
    options.Services.Insert(1,
        new ServiceDescriptor(typeof(TImplementation), provider => null, ServiceLifetime.Singleton));
    // Finally, register our required ISubdependencyA, which is how RootA asks for its own variant.
    // Implement it using our little proxy, which forwards to the TImplementation.
    // The TImplementation is found by asking for all registered ones and the one we put at index 0.
    options.Services.AddSingleton<ISubdependencyA>(provider =>
        new SubdependencyAProxy(provider.GetServices<TImplementation>().First()));
    return options;
}
`
