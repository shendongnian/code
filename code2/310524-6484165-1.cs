    public IQueryable<VehicleResult> Get(bool includeContractorVehicles)
    {
        IQueryable<VehicleResult> query = GetQuery().Select(v => new VehicleResult { ... });
    
        if (includeContractorVehicles == true)
        {
            WorkerRepository rep = new WorkerRepository();
            IQueryable<VehicleResult> contractorsVehicles = rep.GetWorkers().
                Select(x => new VehicleResult()
                {
                    Number = x.ContractorVehicleNumber
                });
            query = query.Union(contractorsVehicles);
        }
    
        return query;
    }  
