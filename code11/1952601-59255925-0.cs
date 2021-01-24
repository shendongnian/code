    [Table("MovieCastRoleMappings")]
    public class MovieCastRoleMapping
    {
        public int fkCastId { get; set; }
        [ForeignKey("fkCastId")]
        public Cast Cast { get; set; }
        public int fkCastRoleId { get; set; }
        [ForeignKey("fkCastRoleId")]
        public CastRole CastRole { get; set; }
        public int fkMovieId { get; set; }
        [ForeignKey("fkMovieId")]
        public Movie Movie { get; set; }
    }
