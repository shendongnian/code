    ...
    using (var conn = new SqlConnection("connection string"))
    {
        using (var cmd = conn.CreateCommand())
        {
            conn.Open();
            //Do stuff with cmd
        }
    }
    ....
