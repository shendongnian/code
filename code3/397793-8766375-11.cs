    public class MovieService : RestServiceBase<Movie>
    {
        private readonly IYellowDbConnectionFactory dbFactory;
        public MovieService(IYellowDbConnectionFactory factory)
        {
            this.dbFactory = factory;
        }
    }
