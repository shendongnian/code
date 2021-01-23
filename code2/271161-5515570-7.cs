    /// <summary>
    /// Load your modules or register your services here!
    /// </summary>
    /// <param name="kernel">The kernel.</param>
    private static void RegisterServices(IKernel kernel)
    {
        kernel.Bind<ISession>().To<SessionImpl>();
        kernel.Bind<IAuthenticationService>().To<AuthenticationService>();
    }
