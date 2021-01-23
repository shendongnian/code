    protected override void OnAfterInstall(IDictionary savedState) {
        base.OnAfterInstall(savedState);
        
        ServiceController sc = new ServiceController(“MyServiceName”);
        sc.Start();
    }
