            // ******
            // Remove Any Duplicate Vehicles
            // ********************
            List<Vehicle> NoDuplicatesVehicleList = ListVehicle.AllVehicles;
            NoDuplicatesVehicleList = NoDuplicatesVehicleList.GroupBy(x => x.VehicleID).Select(x => x.First()).ToList();
