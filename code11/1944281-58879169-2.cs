    public class Team
    {
        public string Name { get; set; } = string.Empty;
        public List<Player> Players { get; set; } = new List<Player>()
        {
            new Player() { Name = "A"},
            new Player() { Name = "B"},
            new Player() { Name = "C"}
        };
    }
