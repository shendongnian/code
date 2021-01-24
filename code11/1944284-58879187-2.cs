    public class Team
    {
        // ...
        public Team(IEnumerable<Player> players)
        {
            Players = new List<Player>(players);
        }
    }
