    public partial class DERSANEM_MASTEREntities : DbContext
    {
        public DERSANEM_MASTEREntities()            
        {
            this.Database.Connection.ConnectionString = CS_Sifreleme.Decrypt("TcF8EGfKWDbCdqgS.........");
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<sysdiagrams> sysdiagrams { get; set; }
        public DbSet<T_HATA_LOG> T_HATA_LOG { get; set; }
        public DbSet<T_MUSTERILER> T_MUSTERILER { get; set; }
    }
