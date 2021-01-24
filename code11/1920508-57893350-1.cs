    public class FirstContext : DbContext
    {
      public DbQuery<Items> Items{get;set;}
      
      public IQueryable<Items> FilterItems(FilterObject filter)
      {
         return filter.ApplyTo(Items.AsQueryable());
      }
    }
