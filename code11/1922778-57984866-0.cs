    IEnumerable<int> ids = getIdsToDelete();
    var idRecords = ids.Select(x => new Inventory { InventoryId = x }).ToList();
    
    using (var context = new MyDbContext())
    {
       foreach(var idRecord in idRecords)
       {
          context.Inventory.Attach(idRecord);
          context.Inventory.Remove(idRecord);
       }
       context.SaveChanges();
    }
