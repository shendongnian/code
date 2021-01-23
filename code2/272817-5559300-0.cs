    public class Team
    {
        public int TeamId { get; set;} 
        public string Name { get; set; }
    
        public virtual ICollection<Match> HomeMatches { get; set; }
        public virtual ICollection<Match> AwayMatches { get; set; }
    }
    
    public class Match
    {
        public int MatchId { get; set; }
    
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }
    
        public float HomePoints { get; set; }
        public float GuestPoints { get; set; }
        public DateTime Date { get; set; }
    
        public virtual Team HomeTeam { get; set; }
        public virtual Team GuestTeam { get; set; }
    }
    
    
    public class Context : DbContext
    {
        ...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                        .HasRequired(m => m.HomeTeam)
                        .WithMany(t => t.HomeMatches)
                        .HasForeignKey(m => m.HomeTeamId)
                        .WillCascadeOnDelete(false);
    
            modelBuilder.Entity<Match>()
                        .HasRequired(m => m.GuestTeam)
                        .WithMany(t => t.AwayMatches)
                        .HasForeignKey(m => m.GuestTeamId)
                        .WillCascadeOnDelete(false);
        }
    }
