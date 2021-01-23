    protected readonly IModuleRepository ModuleRepository;
    public ApplicationController()
    {
        this.ModuleRepository = DependencyResolver.Current.GetService<IModuleRepository>();
        // same for rest or your modules.
    }
