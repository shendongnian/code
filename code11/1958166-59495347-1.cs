    public class MovieProfile: Profile    
    {
        public MovieProfile()
        {
            CreateMap<MovieViewModel, Movie>().ReverseMap();
        }
        
    }
