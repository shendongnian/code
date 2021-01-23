    public class FootballLadder
    {
        private IMatchRepository matchRepo;
        public FootballLadder(IMatchRepository matchRepository)
        {
        }
 
        public int Round { get; set; }
    }
