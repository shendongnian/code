    public class Team
    {
        [Key]
        public int TeamId { get; set;} 
        public string Name { get; set; }
        
        [InverseProperty("HomeTeam")]
        public virtual ICollection<Match> HomeMatches { get; set; }
        [InverseProperty("GuestTeam")]
        public virtual ICollection<Match> GuestMatches { get; set; }
    }
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public float HomePoints { get; set; }
        public float GuestPoints { get; set; }
        public DateTime Date { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team GuestTeam { get; set; }
    }
