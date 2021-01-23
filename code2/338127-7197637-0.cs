    private void TestIOC()
    {
        var container = new WindsorContainer();
        container.Register(
            AllTypes.FromAssemblyContaining<IShouter>()
                    .Where(x => x.Namespace.StartsWith("WindowsBash"))
                    .WithService.AllInterfaces()
                    .ConfigureFor<MessageBye>(c => c.IsDefault()));
    
        var MyShouter = container.Resolve<IShouter>();
        var result = MyShouter.Display();
    }
