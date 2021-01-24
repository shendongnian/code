    public class Team
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; } 
        public Team()
        {
            Name = string.Empty;
            Players = new List<Player>()
            {
                new Player() { Name = "A"},
                new Player() { Name = "B"},
                new Player() { Name = "C"}
            };
        }
    }
