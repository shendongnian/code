    IEnumerable<int> ids = getIdsToDelete();
    
    using (var context = new MyDbContext())
    {
       var idRecords = context.Inventory.Where(x => ids.Contains(x.InventoryId)).ToList();
       foreach(var idRecord in idRecords)
          context.Inventory.Remove(idRecord);
       context.SaveChanges();
    }
