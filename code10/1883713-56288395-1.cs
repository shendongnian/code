    int MyId = ...
    DateTime NewDateTime = ...
    using (YourDbContext dbContext = new YourDbContext())
    {
       YourObject obj = dbContext.YourObjects.SingleOrDefault(item => item.Id == MyId && item.SomeDateTime > NewDateTime)
       if (obj != null)
       {
          obj.SomeDateTime = NewDateTime;
          dbContext.SaveChanges();
       }
    }
