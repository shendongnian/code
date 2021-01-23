    protected void AddFeaturesFromlist(List<int> featureList, GlobalEnums.VehicleFeatureListType type)
    {
        foreach(var item in featureList)
        {
            var acMl =(VOVehicleFeatureList)FrameworkFactoryApi.CreateVO(typeof(VOVehicleFeatureList));
            acMl.IsInitialized = false;
            acMl.Initialize(true);
            acMl.VehicleFeatureListType = type;
            acMl.ValueId = item;
            vehicleSpec.VehicleFeatureLists.Add(acMl);
        }
    }
    AddFeaturesFromlist(VehicleAudioSystem, GlobalEnums.VehicleFeatureListType.AudioSystem);
    ...
