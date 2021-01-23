        class Movie
        {
            public string Title { get; set; }
            public string[] Genres { get; set; }
        }
        static void Main(string[] args)
        {
            var movies = new List<Movie>();
            movies.Add(new Movie { Title = "Pulp Fiction", Genres = new string[] { "Crime", "Thriller" } });
            movies.Add(new Movie { Title = "Back to the Future", Genres = new string[] { "Adventure", "Sci-Fi" } });
            movies.Add(new Movie { Title = "The Dark Knight", Genres = new string[] { "Action", "Crime" } });
            var byTitle = from m in movies orderby m.Title select m;
            var crimeMovies = from m in movies where m.Genres.Contains("Crime") orderby m.Title select m;
        }
