    public IList<object[]> FindUsers()
    {
        using (var command = dbConn.CreateCommand())
        {
            command.CommandText =  "SELECT * FROM users";
            using (var reader = command.ExecuteReader())
            {
                var rows = new List<object[]>();
                while (reader.Read()) 
                {
                    var columns = new object[reader.FieldCount];
                    reader.GetValues(columns);
                    rows.Add(columns);
                }
                return rows;
            }
        }
    }
