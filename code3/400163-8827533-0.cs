    public class MoviesWithTheatersCount : AbstractMultiMapIndexCreationTask<MoviesWithTheatersCount.ReduceResult>
    {
        public class ReduceResult
        {
            public string State { get; set; }
            public string MovieName { get; set; }
            public int TheaterCount { get; set; }
        }
        public MoviesWithTheatersCount()
        {
            AddMap<Movie>(movies => from movie in movies
                                    select new
                                               {
                                                   State = movie.State,
                                                   MovieName = movie.Name,
                                                   TheaterCount = 0
                                               });
            AddMap<Theater>(theaters => from theater in theaters
                                        select new
                                                   {
                                                       State = theater.State,
                                                       MovieName = (string)null,
                                                       TheaterCount = 1
                                                   });
            Reduce = results => from result in results
                                group result by result.State
                                into g
                                select new
                                           {
                                               State = g.Key,
                                               MovieName = g.Select(x => x.MovieName != null).First(),
                                               TheaterCount = g.Sum(x => x.TheaterCount)
                                           };
        }
    }
