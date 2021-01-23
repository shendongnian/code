    public void OnStartup(args){
        var container = new IoCContainerOfChoice();
    
        Types.FromThisAssembly()
            .ForEach(type => container.Register(type, type.DefaultInterface());
    
        container.Resolve<ShellView>();
    }
