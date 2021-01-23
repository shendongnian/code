    try
    {
        using (var sc = new SqlConnection(ConnectionString))
        using (var cmd = sc.CreateCommand())
        {
            sc.Open();
            cmd.CommandText = "DELETE FROM excludes WHERE word = @word";
            cmd.Parameters.AddWithValue("@word", word);  
            cmd.ExecuteNonQuery();
        }
    }
    catch (Exception e)
    {
        Box.Text = "SQL error" + e;
    }
    ...
