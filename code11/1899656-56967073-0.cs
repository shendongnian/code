    public class MyContext : DbContext
    {
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
        modelBuilder.Entity<Companies>()
                .HasOne(c => c.CompanyId)
                .WithMany(a => a.ApiRedirects)
                .HasForeignKey(a => a.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
      }
    }
