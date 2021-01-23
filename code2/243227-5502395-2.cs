    public class myContext : DbContext, IUnitOfWork
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Addresses> Address { get; set; }
    
        public void Save()
        {
            SaveChanges();
        }
    }
