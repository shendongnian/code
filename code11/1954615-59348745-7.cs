    public class Achievement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserAchievement> UserAchievements { get; set; }
    }
    
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public ICollection<UserAchievement> UserAchievements { get; set; }
    }
