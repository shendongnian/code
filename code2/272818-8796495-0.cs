    public class Match
    {
        [Key]
        public int MatchId { get; set; }
    
        [ForeignKey("HomeTeam"), Column(Order = 0)]
        public int? HomeTeamId { get; set; }
        [ForeignKey("GuestTeam"), Column(Order = 1)]
        public int? GuestTeamId { get; set; }
    
        public float HomePoints { get; set; }
        public float GuestPoints { get; set; }
        public DateTime Date { get; set; }
    
        public virtual Team HomeTeam { get; set; }
        public virtual Team GuestTeam { get; set; }
    }
