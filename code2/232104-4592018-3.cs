    public class FootballLadder
    {
        private IMatchRepository matchRepo;
        private int round;
        public FootballLadder(IMatchRepository matchRepository,
            IRoundProvider roundProvider)
        {
           this.round = roundProvider.GetRound();
        }        
    }
