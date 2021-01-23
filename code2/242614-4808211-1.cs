    string[] batches = SplitBatches(System.IO.File.ReadAllText(fileName));
    
    conn.Open();
    
    using(SqlCommand cmd = conn.CreateCommand())
    {
        foreach(string batch in batches)
        {
            cmd.CommandText = batch;
            cmd.ExecuteNonQuery();
        }
    }
