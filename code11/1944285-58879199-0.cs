    class Program
    {
        static void Main(string[] args)
        {
            var team = new Team("Juventus",
                new List<Player>
                {
                    new Player("Ronaldo"), 
                    new Player("Messi")
                });
        }
    }
    public class Player
    {
        public string Name { get; set; }
        public Player(string name)
        {
            Name = name;
        }
    }
    public class Team
    {
        public string Name { get; set; }
        public IEnumerable<Player> Players { get; set; }
        public Team(string name, IEnumerable<Player> players)
        {
            Name = name;
            Players = players;
        }
    }
