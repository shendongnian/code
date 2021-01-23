    using (BissEntities context = new BissEntities())
    {
      if (adCategoryFilter.Id < 1)
        context.AdCategoryFilters.AddObject(adCategoryFilter);
      else {
         var stub = new AdCategoryFilters { Id = adCategoryFilter.Id };
         context.AdCategoryFilters.Attach(stub);
         context.AdCategoryFilters.ApplyCurrentValues(adCategoryFilter);
      }
      
      context.SaveChanges();
    }
