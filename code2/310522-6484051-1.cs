    public class VehicleDTO
    {
      public int Id { get; set; }
      public int Number { get; set; }
    } 
    
    public IQueryable<VehicleDTO> Get(bool includeContractorVehicles)
    {
        var query = GetQuery().Select(x => new VehicleDTO(){ ID = c.ID, Number = c.Number });
    
        if (includeContractorVehicles)
        {
            WorkerRepository rep = new WorkerRepository();
            var contractorsVehicles = rep.GetWirkers().
                Select(x => new VehicleDTO(){ Number = x.ContractorVehicleNumber});
            query = query.Union(contractorsVehicles);
        }
        
        return query;
    } 
