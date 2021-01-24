    [Table("MovieCastRoleMappings")]
    public class MovieCastRoleMapping
    {
        [Key, Column(Order = 0)]
        public int fkCastId { get; set; }
        [ForeignKey("fkCastId")]
        public Cast Cast { get; set; }
        [Key, Column(Order = 1)]
        public int fkCastRoleId { get; set; }
        [ForeignKey("fkCastRoleId")]
        public CastRole CastRole { get; set; }
        [Key, Column(Order = 2)]
        public int fkMovieId { get; set; }
        [ForeignKey("fkMovieId")]
        public Movie Movie { get; set; }
    }
