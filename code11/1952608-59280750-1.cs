    public class ImdbContext : DbContext
    {
        public DbSet<Cast> Cast { get; set; }
        public DbSet<CastRole> CastRole { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieCastRoleMapping> MovieCastRoleMapping { get; set; }
    
        public ImdbContext() : base("ImdbDbContext")
        {
        }
    }
    
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int movieId { get; set; }
        public string movieName { get; set; }
        public string movieYear { get; set; }
        public string movieLink { get; set; }
        public string movieImageUrl { get; set; }
    }
    [Table("CastRoles")]
        public class CastRole
        {
            [Key]
            public int castRoleId { get; set; }
            public string castRoleName { get; set; }   
        }
    [Table("Casts")]
    public class Cast
    {
        [Key]
        public int castId { get; set; }
        public string nameSurname { get; set; }
        public string biography   { get; set; }
    }
    [Table("MovieCastRoleMappings")]
    public class MovieCastRoleMapping
    {
        [Key, Column(Order = 1)]
        public int fkCastId { get; set; }
        [ForeignKey("fkCastId")]
        public virtual Cast Cast { get; set; }
    
        [Key, Column(Order = 2)]
        public int fkCastRoleId { get; set; }
        [ForeignKey("fkCastRoleId")]
        public virtual CastRole CastRole { get; set; }
    
        [Key, Column(Order = 3)]
        public int fkMovieId { get; set; }
        [ForeignKey("fkMovieId")]
        public virtual Movie Movie { get; set; }
    }
