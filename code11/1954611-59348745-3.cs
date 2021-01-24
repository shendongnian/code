    public class DataContext : DbContext
    {
    
        private override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAchievement>().HasKey(ua => new { ua.UserId, ua.AchievementId });
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<UserAchievement> UserAchievements { get; set; }
    }
