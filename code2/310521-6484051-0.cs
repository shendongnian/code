    public IQueryable<int> Get(bool includeContractorVehicles)
    {
        var query = GetQuery().Select(x => c.Number);
    
        if (includeContractorVehicles)
        {
            WorkerRepository rep = new WorkerRepository();
            var contractorsVehicles = rep.GetWirkers().
                Select(x => x.ContractorVehicleNumber);
            query = query.Union(contractorsVehicles);
        }
    
        return query;
    } 
