    string result;
    using (var con = new SqlConnection(...))
    {
        var com = con.CreateCommand();
        com.CommandText = "select 'hello world'";
        result = com.ExecuteScalar();
    }
