public class VehicleServiceDTO
{
   public Vehicle Vehicle { get; set; }
   public ServiceInterval Repair { get; set; }
}
public IQueryable<VehicleServiceDTO> GetVehicles()
{
    return
        from v in _context.Vehicles
        join si in _context.ServiceIntervals on v.Id equals si.VehicleId into loj
        from rs in loj.DefaultIfEmpty()
        where
            v.Schedule == true
            && v.Suspend == false
        select new VehicleServiceDTO() { Vehicle = v, Repair = rs };
}
