    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(AllTypes.FromThisAssembly().BasedOn<ISomething>()
                           .WithService.DefaultInterface()
                          );
    }
