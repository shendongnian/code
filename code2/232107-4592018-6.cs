    public class CastleFootballLadderFactory : IFootballLadderFactory
    {
        public IWindsorContainer Container;
        public FootballLadder CreateNew(int round)
        {
            var ladder = this.Container.Resolve<FootballLadder>();
            ladder.Round = round;
            return ladder;
        }
    }
