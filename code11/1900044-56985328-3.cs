    var inventory = context.Inventory.FirstOrDefault(x => x.Id == Model.InventoryId);
     //check if inventory is not null if not continue
     if (inventory.Version != Model.Version)
     {
          //throw exception, DbContextConcurrencyIssue, error handling codes
     }
     else
     {
         //continue with process
     }
