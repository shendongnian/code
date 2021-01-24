     List<Movies> Movies = new List<Movies>();
         while (reader.Read())
         {
            Movies movie = new Movies()
            {
              MovieTitle = reader["MovieTitle"].ToString();
              MovieYear = Convert.ToInt32(reader["MovieYear"]);
            }
            Movies.Add(movie);
         }
         return Movies;
