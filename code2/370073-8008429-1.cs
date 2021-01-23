    using (var db = new DataModel.ModelDataContext() ) 
    {
        return
            from c in db.Campaigns.WithContractCount()
            select new
            {
                Id = c.Campaign.Id,
                Name = c.Campaign.Name,
                Status = c.ContractsCount 
            };
    }
 
