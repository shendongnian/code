    private static void bootstrapContainer()
    {
        container = new WindsorContainer()
            .Install(FromAssembly.This());
        var controllerFactory = new WindsorControllerFactory(container.Kernel);
        ControllerBuilder.Current.SetControllerFactory(controllerFactory);
    }
