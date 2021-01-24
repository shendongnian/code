c# 
services.AddEntityFrameworkSqlite().AddDbContext<ApplicationDbContext>();
 and delete
c#
services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<ProductContext>();
in startup.
the error was about bad startup configuration.
Was sending too much things.
ApplicationDbContext:
c#
 public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public Microsoft.EntityFrameworkCore.DbSet<Product> Products { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<List> Lists { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<ProductList> ProductLists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
             optionsBuilder.UseSqlite("Data Source=assistant.db");
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductList>()
                .HasKey(pl => new { pl.ProductId, pl.ListId });
            modelBuilder.Entity<ProductList>()
                .HasOne(pl => pl.Product)
                .WithMany(p => p.ProductList)
                .HasForeignKey(pl => pl.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ProductList>()
                .HasOne(pl => pl.List)
                .WithMany(l => l.ProductList)
                .HasForeignKey(pl => pl.ListId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
