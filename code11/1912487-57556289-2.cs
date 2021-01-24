    public class SchoolContext : DbContext
    {
    
    public SchoolContext() : base("SchoolContext")
    {
    }
    
    public DbSet<Student> Students { get; set; }
    
    public virtual new DbSet<TEntity> MySet<TEntity>() where TEntity : BaseEntity
    {
        return base.Set<TEntity>();
    }
    }
