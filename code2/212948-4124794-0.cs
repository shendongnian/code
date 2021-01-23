        string _connStr = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True;User Instance=True";
        string _query = "INSERT INTO Table1 VALUES ('MS','AH','BOSS')";
        using (SqlConnection _conn = new SqlConnection(_connStr))
        {
            SqlCommand _com = _conn.CreateCommand();
            _conn.Open();
            _com.CommandText = _query;
            _com.ExecuteNonQuery();
        }
