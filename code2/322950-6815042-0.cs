    public abstract class League<T> where T : Team
    {
        protected IList<T> mTeams;
        public League()
        {
            mTeams = new List<T>();
        }
    }
    public class FootballLeague : League
    {
    }
