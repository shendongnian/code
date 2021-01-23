    public void AddVehiculeFeatures(IEnumerable<int> featureList, GlobalEnums.VehicleFeatureListType listType, Vehicle vehicleSpec)
    {
     foreach(int feature in featureList)
     {
      var acMl = (VOVehicleFeatureList)FrameworkFactoryApi.CreateVO(typeof(VOVehicleFeatureList));             
      acMl.IsInitialized = false;             
      acMl.Initialize(true);             
      acMl.VehicleFeatureListType = listType;            
      acMl.ValueId = nav;             
      vehicleSpec.VehicleFeatureLists.Add(acMl);             
      
     }
    }
