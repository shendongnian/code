    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions options) : base(options) {}
        // We add a GUID here so we're able to tell it's the same object later.
        public string Id { get; } = Guid.NewGuid().ToString();
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
    public class Cart
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class Order
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
