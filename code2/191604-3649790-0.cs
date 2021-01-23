    var cmd = new MySqlCommand("...lot of SQL selects...");
    using (var reader = cmd.ExecuteReader())
    {
        // Go to a 'next result' each time.
        while (reader.NextResult())
        {
            while (reader.Read())
            {
                // Read data from result set.
            }
        }
    }
