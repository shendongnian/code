    public static void Main()
    {
        var kernel = new StandardKernel();
        kernel.Bind<IWeapon>().To<Sword>();
        // Optional, Ninject will try to resolve any non-registered concrete type.
        kernel.Bind<Samuari>().ToSelf();
        var samurai = kernel.Get<Samuari>();
    }
