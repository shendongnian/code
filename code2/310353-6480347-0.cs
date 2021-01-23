    public class MyContext: DbContext
    {
         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
           modelBuilder.Entity<Order>().HasKey(x => x.OrderId);
           base.OnModelCreating(modelBuilder);
         }
    }
