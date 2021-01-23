    public class DIFootballLadder : FootballLadder
    {
        private const int Round = 3;
        public DIFootballLadder(IMatchRepository matchRepository)
            : base(matchRepository, Round)
        {
        }
    }
