     public class OrderDetailsContext : DbContext
        {
            public OrderDetailsContext(DbContextOptions<OrderDetailsContext> options) : base(options)
            { }
    
            //defining table
            public DbSet<OrderDetails> OrderDetails { get; set; }
        }
