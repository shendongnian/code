    public class Team
    {
        // ...
        public Team()
        {
            Players = new List<Player>();
            this.Players.Add(new Player());
            this.Players.Add(new Player());
        }
    }
