    public static IQueryable<Vehicle> GetVehicles()
    {
        return _context.Vehicles
            .Where(v => v.Schedule && !v.Suspend)
            .GroupJoin(_context.ServiceIntervals,
                v => v.Id,
                si => si.VehicleId,
                (v, si) => SetServiceIntervals(v, si));
    }
