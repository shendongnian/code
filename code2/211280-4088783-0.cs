    internal interface IBallConfigurer
    {
        bool CanExplode { get; }
    }
    
    internal class BallConfigurer : IBallConfigurer
    {
        public bool CanExplode
        {
            get
            {
                bool BallsCanExplode;
                bool.TryParse(ConfigurationManager.AppSettings["ballsCanExplode"],
            out BallsCanExplode);
                return BallsCanExplode;
    
            }
        }
    }
    
    public class Ball
    {
        private bool canExplode;
    
        public Ball()
            :this(new BallConfigurer())
        {
    
        }
    
        internal Ball(IBallConfigurer ballConfigurer)
        {
            this.canExplode = ballConfigurer.CanExplode;
        }
    }
