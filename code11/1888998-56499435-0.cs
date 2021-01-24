    IUnityContainer container = new UnityContainer();
    container.RegisterType<ICar, BMW>();
    container.RegisterType<ICar, Audi>("LuxuryCar");
    
    ICar bmw = container.Resolve<ICar>();  // returns the BMW object
    ICar audi = container.Resolve<ICar>("LuxuryCar"); // returns the Audi object
