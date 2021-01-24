    public class Profile
    {
        public Profile()
        {
            Achievements = new List<Achievement>
            {
                // initialize 3 achievements
                new Achievement(),
                new Achievement(),
                new Achievement()
            };
        }
        public string Username { get; set; }
        public List<Achievement> Achievements { get; set; }
    }
    public class Achievement
    {
        public int Rank { get; set; }
        public int EventId { get; set; }
    }
