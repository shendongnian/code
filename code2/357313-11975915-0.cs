    public Vehicle GetVehicle(VehicleRegistrant registrant)
    {
        var vehicle = session.Query<Vehicle>()
                             .FetchMany(x => x.VehicleRegistrants)
                             .ThenFetch(x => x.Owner)
                             .Where(x => x.VehicleRegistrants.Contains(registrant))
                             .SingleOrDefault();
    }
