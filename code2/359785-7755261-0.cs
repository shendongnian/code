        foreach (var vaudioSystem in VehicleAudioSystem)
            AddFeature(vaudioSystem, GlobalEnums.VehicleFeatureListType.AudioSystem);
        foreach(var axle in VehicleAxles)
            AddFeature(axle, GlobalEnums.VehicleFeatureListType.Axles);
        foreach(var nav in VehicleNavSystem)
            AddFeature(nav, GlobalEnums.VehicleFeatureListType.NavSystem);
    [...]
    public static void AddFeature(int id, VehicleFeatureListType type)
    {
        var acMl = (VOVehicleFeatureList)FrameworkFactoryApi.CreateVO(
            typeof(VOVehicleFeatureList));
        acMl.IsInitialized = false;
        acMl.Initialize(true);
        acMl.VehicleFeatureListType = type;
        acMl.ValueId = id;
        vehicleSpec.VehicleFeatureLists.Add(acMl);
    }
