    public interface IApplicationDbContext
    {
        DbSet<Company> Companies { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
        IDbSet<IdentityRole> Roles { get; set; }
        DbSet<T> Set<T>() where T: class;
        int SaveChanges();
    }
