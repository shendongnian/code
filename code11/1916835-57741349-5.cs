    public class Context : DbContext {
        public DbSet<MarketCategory> MarketCategories { get; set; } 
        public DbSet<InventoryAsset> InventoryAssets { get; set; } 
        public DbSet<ItemCategory> ItemCategories { get; set; } 
    }
