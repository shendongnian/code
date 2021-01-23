    foreach (var item in
        VehicleAudioSystem.Select(id => new { id, type = GlobalEnums.VehicleFeatureListType.AudioSystem }).Concat(
        VehicleAxles.Select(id => new { id, type = GlobalEnums.VehicleFeatureListType.Axles }).Concat(
        VehicleNavSystem.Select(id => new { id, type = GlobalEnums.VehicleFeatureListType.NavSystem }))))
    {
        var acMl = (VOVehicleFeatureList)FrameworkFactoryApi.CreateVO(typeof(VOVehicleFeatureList));
        acMl.IsInitialized = false;
        acMl.Initialize(true);
        acMl.VehicleFeatureListType = item.type;
        acMl.ValueId = item.v;
        vehicleSpec.VehicleFeatureLists.Add(acMl);
    }
