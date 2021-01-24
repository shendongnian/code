    class Player
    {
        public string Name;
        public string Team;
        public int Score ;
    }
    
    class Container
    {
        private List<Player> _players;
    
        public void Add(Player p) => _players.Add(p);
    
        public List<(string Team, int Sum)> GetTeamStats()
        {
            var list = _players.GroupBy(g =>  g.Team ).Select(r => new { Team = r.Key, Sum = r.Sum(s => s.Score) });
            return list.Select(r => (r.Team, r.Sum)).ToList();
        } 
    
        public Container()
        {
            _players = new List<Player>();
    
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
