    class PurchaseProduct
    {
        public int Id {get; set;}
        public double A {get; set;}
        public double B {get; set;}
        ...
        // every PurchaseProduct has zero or more ProductStocks (one-to-many)
        public virtual ICollection<ProductStock> ProductStocks {get; set;}
    }
    class ProductStock
    {
        public int Id {get; set;}
        public double C {get; set;}
        ...
        // every ProductStock belongs to exactly one PurchaseProduct, using foreign key
        public int PurchaseProductId {get; set;}
        public virtual PurchaseProduct PurchaseProduct {get; set;}
    }
    class MyDbContext : DbContext
    {
         public DbSet<PurchaseProduct> PurchaseProducts {get; set;}
         public DbSet<ProductStock> ProductStocks {get; set;}
    }
