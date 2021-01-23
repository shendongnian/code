    public class AlbumDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }        
        public DbSet<Photo> Photos { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {    
            modelBuilder.Configurations.Add(new Album.AlbumConfiguration());          
        }
    }
