    public List<Movies> GetMovieByMedia(byte? MediaID)
    {
        string connectionString = "Server=ServerName;Database=Movies;Trusted_Connection=True;MultipleActiveResultSets=true";
        var movies = new Movies();
        using (var con = new SqlConnection(connectionString))
        {
            using (var cmd = new SqlCommand("usp_MovieByMedia", con))
            {
                cmd.Parameters.Add(new SqlParameter("@MediaID", SqlDbType.TinyInt) { Value = MediaID });
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
    
                using (var reader = cmd.ExecuteReader())
                {
                    List<Movies> Movies = new List<Movies>();
                    while (reader.Read())
                    {
                         Movies movie = new Movies()
                                        {
                                             MovieTitle = reader["MovieTitle"].ToString(),
                                             MovieYear = Convert.ToInt32(reader["MovieYear"])
                                        };
                         Movies.Add(movie);
                    }
                }
                return Movies;
    }
