    public interface IMyDbContext
    {
        DbSet<Staff> Staff { get; }
        DbChangeTracker ChangeTracker { get; }
        int SaveChanges();
    }
    public interface IAuditableEntity
    {
        string CreatedBy { get; set; }
    }
    public interface ICurrentUser
    {
        string Name();
    }
