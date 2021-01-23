    using (var context = new MyContext(...))
    {
        var existingVehicle = context.Vehicles.Include("Drivers")
            .First(v => v.Name == "Ford");
        foreach(var driver in existingVehicle.Drivers.ToList())
        {
            if (!context.Drivers.Any(d => d.DriverId == driver.DriverId
                && d.Vehicles.Any(v => v.VehicleId != existingVehicle.VehicleId)))
                context.Drivers.DeleteObject(driver);
        }
        context.Vehicles.DeleteObject(existingVehicle);
         
        context.SaveChanges();
    }
