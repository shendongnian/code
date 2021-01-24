    /// <summary>
    /// Builds an instance of the specified <typeparamref name="TFunctionType"/>
    /// with the services defined in the <paramref name="startup"/> instance.
    /// </summary>
    /// <typeparam name="TFunctionType"></typeparam>
    /// <param name="startup"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if:
    /// - The <paramref name="startup" /> instance is not specified.
    /// </exception>
    public static TFunctionType Instanciate<TFunctionType>(Startup startup)
    {
        Argument.ThrowIfIsNull(startup, nameof(startup));
        // --> Builds an IHost with all the services registered in the Startup.
        IHost host = new HostBuilder().ConfigureWebJobs(startup.Configure).Build();
        return Instanciate<TFunctionType>(host);
    }
