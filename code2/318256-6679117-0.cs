    List<Contracts> excludedContracts = 
                (from Excluded in DataContext.ExcludedTransportContracts
                 select Excluded).toList();
    
    List<Contracts> liveContracts = 
        (from Contracts in DataContext.Contracts
         where Contracts.EndDate > DateTime.Now &&
                !excludedContracts.Contains(Contracts)
         select Contracts).toList();
