       public class MyContext : DbContext
        {
            private string oracleSchema;
            
            public MyContext()
                : base("OracleConnectionString")
            {
                Database.SetInitializer<MyContext>(null);
    
                oracleSchema = new System.Data.SqlClient.SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString).UserID.ToUpper();
    
            }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Customer>().ToTable(string.Format("{0}.{1}", oracleSchema, "CUSTOMER"));
                modelBuilder.Entity<Invoice>().ToTable(string.Format("{0}.{1}", oracleSchema, "INVOICE"));
                modelBuilder.Entity<Product>().ToTable(string.Format("{0}.{1}", oracleSchema, "PRODUCT"));
                modelBuilder.Entity<Category>().ToTable(string.Format("{0}.{1}", oracleSchema, "CATEGORY"));
                modelBuilder.Entity<Item>().ToTable(string.Format("{0}.{1}", oracleSchema, "ITEM"));
    
                modelBuilder.Entity<Invoice>().HasRequired(p => p.Customer);
    
                modelBuilder.Entity<Item>().HasRequired(p => p.Invoice);
                modelBuilder.Entity<Item>().HasRequired(p => p.Product);
    
                modelBuilder.Entity<Product>()
                            .HasMany(x => x.Categories)
                            .WithMany(x => x.Products)
                            .Map(x =>
                            {
                                x.ToTable("ASS_CATEGORY_PRODUCT", oracleSchema);
                                x.MapLeftKey("ID_CATEGORY");
                                x.MapRightKey("ID_PRODUCT");
                            });
    
                modelBuilder.Entity<Category>()
                            .HasMany(x => x.Products)
                            .WithMany(x => x.Categories)
                            .Map(x =>
                            {
                                x.ToTable("ASS_CATEGORY_PRODUCT", oracleSchema);
                                x.MapLeftKey("ID_PRODUCT");
                                x.MapRightKey("ID_CATEGORY");
                            });
            }
    
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Invoice> Invoices { get; set; }
            public DbSet<Item> Items { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Category> Categories { get; set; }
        }
