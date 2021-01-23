    public class Team
    {    
        public int TeamId { get; set; }
        public ICollection<Player> TeamMembers { get; set; } 
        public Player CreatedBy { get; set; } 
    }
    public class Player
    {
        public int PlayerId { get; set; }
        public Team Team { get; set; } 
    }       
        
    public class Context : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                        .HasOptional(p => p.Team)
                        .WithMany(t => t.TeamMembers)
                        .Map(c => c.MapKey("TeamId"));
            
            // Or alternatively you could start from the Team object:
            modelBuilder.Entity<Team>()
                        .HasMany(t => t.TeamMembers)
                        .WithOptional(p => p.Team)
                        .Map(c => c.MapKey("TeamId"));
        }
    }
