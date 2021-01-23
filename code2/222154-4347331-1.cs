    // this will work, because it's executed on SQL-side
    db.Items
          .Select(x=>new { CatId = (int?)x.Category.Id, x.Id})
          .ToList();
    // this will throw NullRefException, because it's executed against collection in .Net environment, not on SQL Server.
    db.Items
          .ToList()
          .Select(x=>new { CatId = (int?)x.Category.Id, x.Id}); 
