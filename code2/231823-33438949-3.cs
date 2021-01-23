    var kernel = new StandardKernel();
    kernel.Components.Add<IBindingResolver, ContravariantBindingResolver>();
    kernel.Bind(scan => scan.FromAssemblyContaining<IMediator>()
        .SelectAllClasses()
        .BindDefaultInterface());
    kernel.Bind(scan => scan.FromAssemblyContaining<Ping>()
        .SelectAllClasses()
        .BindAllInterfaces());
    kernel.Bind<TextWriter>().ToConstant(Console.Out);
