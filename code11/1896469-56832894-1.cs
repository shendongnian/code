    public NavigationShell()
    {
       Routing.RegisterRoute("targetPageRoute", typeof(TargetPage));
       BindingContext = this;
    }
