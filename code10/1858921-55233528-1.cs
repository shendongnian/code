     public void Create(IEnumerable<CollectionModel> p )
     {
       foreach (var asa in p)
         {   
           collection module = new collection();            
           module.AccountId = 1;
           module.Amount = asa.Amount;
           module.NameSou = asa.NameSou;
           module.Date = asa.Date;
           module.CreatedDatetime = DateTime.Now;
           module.UpdatedDatetime = DateTime.Now;
          _context.collection.Add(module);
        }
       _context.SaveChanges();
     }
