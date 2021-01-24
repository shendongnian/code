     public void Create(IEnumerable<CollectionModel> args )
     {
        var modules = args.Select(asa=> new collection{
           AccountId = 1,
           Amount = asa.Amount,
           NameSou = asa.NameSou,
           Date = asa.Date,
           CreatedDatetime = DateTime.Now,
           UpdatedDatetime = DateTime.Now
          }).ToList(); 
        _context.collection.AddRange(modules);
       _context.SaveChanges();
    }
