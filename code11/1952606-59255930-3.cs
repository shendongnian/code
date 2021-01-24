    public class Movie
    {
        public int movieId { get; set; }
        public string movieName { get; set; }
        public string movieYear { get; set; }
        public string movieLink { get; set; }
        public string movieImageUrl { get; set; }
        public virtual List<Cast> Casts { get; set; }
    }
    public class Cast
    {
        public int castId { get; set; }
        public string nameSurname { get; set; }
        public string biography   { get; set; }
     
        public int MovieId { get; set;}
        public virtual Movie Movie { get; set; }
        public int CastRoleId { get; set;}
        public virtual CastRole CastRole { get; set; }
    }
    public class CastRole
    {
        public int castRoleId { get; set; }
        public string castRoleName { get; set; }
        public virtual Cast Cast { get; set; }
    }
    
    
    public class ImdbContext : DbContext
    {
        public DbSet<Cast> Casts { get; set; }         // Table name will be "Casts"
        public DbSet<CastRole> CastRoles { get; set; } // Table name will be "CastRoles"
        public DbSet<Movie> Movies { get; set; }       // Table name will be "Movies"
        
        public ImdbContext() : base("ImdbDbContext")
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting primary keys
            modelBuilder.Entity<Movie>()
                        .HasKey<int>(x => x.movieId);
            modelBuilder.Entity<Cast>()
                        .HasKey<int>(x => x.castId);
            modelBuilder.Entity<CastRole>()
                        .HasKey<int>(x => x.castRoleId);
            modelBuilder.Entity<Movie>()
                        .HasMany<Cast>(x => x.Casts)
                        .WithRequired(s => s.Movie)
                        .HasForeignKey<int>(x => x.MovieId);
            modelBuilder.Entity<Cast>()
                        .HasRequired(x => x.CastRole)
                        .WithRequiredPrincipal(x => x.Cast);
            // Creating Model
            base.OnModelCreating(modelBuilder);
        }
    }
