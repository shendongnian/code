    IEnumerable<IDataRecord> GetRecords()
    {
        using(var connection = new SqlConnection(@"..."))
        {
            connection.Open();
    
            using(var command = new SqlCommand(@"...", connection);
            {
                using(var reader = command.ExecuteReader())
                {
                   while(reader.Read())
                   {
                       // your code here.
                       yield return reader;
                   }
                }
            }
        }
    }
