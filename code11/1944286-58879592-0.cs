    public class Team
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Player> Players { get; set; } = new List<Player>();
    }
