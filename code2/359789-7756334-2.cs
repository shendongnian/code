        private void AddToVehicleFeatureList<T>(T VehicleParameterType)
            where T : VehicleFeatureList
        {
            foreach (var item in VehicleParameterType)
            {
                var acMl =
               (VOVehicleFeatureList)FrameworkFactoryApi.CreateVO(typeof(VOVehicleFeatureList));
                acMl.IsInitialized = false;
                acMl.Initialize(true);
                acMl.VehicleFeatureListType = item.VehicleFeatureListType;
                acMl.ValueId = item.ValueId;
                vehicleSpec.VehicleFeatureLists.Add(acMl);        
            }
        }
