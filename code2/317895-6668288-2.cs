            var distinctGenres = from m in movies
                                 from genre in m.Genres
                                 group genre by genre into genres
                                 select genres.First();                          
            var moviesWithGenre = from g in distinctGenres
                                  from m in movies
                                  where m.Genres.Contains(g)
                                  orderby g, m.Title
                                  select new { Genre = g, Movie = m };
            foreach (var m in moviesWithGenre)
            {
                Console.WriteLine("Genre: "+ m.Genre + " - " + m.Movie.Title);
            }
