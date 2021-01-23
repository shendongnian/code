    public class ItemsContext : DbContext
    {
        public ItemsContext()
        : base("DefaultConnection")
        {
        }
  
        public DbSet<Item> Items { get; set; }
    }
