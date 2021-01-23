    public class PlayerTeam : IEntityKey<Tuple<int, int>>
    {
        Tuple<int, int> IEntityKey<Tuple<int, int>>.Id
        {
            get { return Tuple.Create(PlayerId, TeamId); }
        }
    
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
    }
