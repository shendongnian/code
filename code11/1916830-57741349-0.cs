    public class Context : DbContext {
        public DbSet<MarketCategory> MarketCategories { get; set; } //has .name
        public DbSet<InventoryAsset> InventoryAssets { get; set; } //has .name
        public DbSet<ItemCategory> ItemCategories { get; set; } // has .name
    }
