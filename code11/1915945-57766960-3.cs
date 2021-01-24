    public partial class MyDBContext: DbContext, IDBContext
    {
        public MyDBContext() : base("name=MyDBContext")
        {
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        
        public virtual DbSet<file> file{ get; set; }
    }
    
    public interface IDBContext : IDisposable
    {
        DbSet<file> file { get; set; }
    }
