    class Player
    {
        public string Name { get; set; };
        public string Team { get; set; };
        public int Score { get; set; };
    }
    
    class Container
    {
        private List<Player> _players;
        public Container()
        {
            _players = new List<Player>();
        }    
        public void Add(Player p) => _players.Add(p);
        public List<(string Team, int Sum)> GetTeamStats()
        {
            return _players
                .GroupBy(g => g.Team)
                .Select(r => ( Team : r.Key, Sum : r.Sum(s => s.Score)));
                .ToList();
        } 
    }
    
    class Program
    {
         static void Main(string[] args)
        {
            var cont = new Container();
    
            cont.Add(new Player { Name = "Matt", Score = 15, Team="Alfa" });
            cont.Add(new Player { Name = "Oreo", Score = 5, Team = "Beta" });
            cont.Add(new Player { Name = "Bean", Score = 7, Team = "Alfa" });
    
            var teamStats = cont.GetTeamStats();
            foreach (var team in teamStats)
            {
                Console.WriteLine($"{team.Team} {team.Sum}");
            }
        }
    }
