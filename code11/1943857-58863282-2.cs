    public static long AddMovie(Movie movie)
    {
        string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DB_FILENAME);
        using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
        {
            db.Open();
    
            SqliteCommand cmd = new SqliteCommand();
            cmd.Connection = db;
    
            cmd.CommandText = "INSERT INTO Movie VALUES (NULL, @Title, @Rating); SELECT last_insert_rowid();";
            cmd.Parameters.AddWithValue("@Title", movie.Title);
            cmd.Parameters.AddWithValue("@Rating", movie.Rating);
    
            return (long)cmd.ExecuteScalar();
        }
    }
