     public class BlogContext : DbContext
     {
     public DbSet<Post> Posts { get; set; }
     public BlogContext(DbContextOptions<BlogContext> options) : base(options)
     {
     }
     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         base.OnModelCreating(modelBuilder);
         modelBuilder.Entity<Post>().Property(p => p.Text).HasDefaultValue("Default");
     }
  }
