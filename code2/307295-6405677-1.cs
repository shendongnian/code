    protected override IModuleCatalog GetModuleCatalog()
    {
        var CarListModule = new ModuleInfo()
        {
            ModuleName = "CarList",
            ModuleType = "Car.CarList.InitModule, Car.CarList, Version=1.0.0.0",
            Ref = "CarList.xap?Version=x.y.z.a",
            InitializationMode = InitializationMode.OnDemand,
        };
        // blah
    }
