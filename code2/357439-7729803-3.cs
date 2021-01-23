    void RootMethod1()
    {
        var container = BuildContainer();
        var controller = container.Resolve<Controller>("ControllerWithViewA");
        controller.Load();
    }
    void RootMethod2()
    {
       var controller = container.Resolve<Controller>("ControllerWithViewB");
       controller.Load();
    }
