    var viewModels = db.Jobs
        .Where(x => x.Account == id 
        && x.Status == "Completed"
        && x.Bids.Any(b => b.Status == "Completed"))
        .Select(x => new JobViewModel
        {
           AccountId = x.Account,
           Account = x.Account1.Select(a => new AccountViewModel 
           { 
               AccountId = a.Id,
               // ...
           },
           Bids = x.Bids.Where(b => b.Status == "Completed)
               .Select(b => new BidViewModel 
               {
                   BidId = b.Id,
                   // ...
               }).ToList()
        }).ToListAsync();
