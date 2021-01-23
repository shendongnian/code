    protected readonly IModuleRepository ModuleRepository;
    // same for the rest...    
    public ApplicationController()
    {
        this.ModuleRepository = MvcApplication.Container.Get<IModuleRepository>();
        // same for rest or your modules.
    }
