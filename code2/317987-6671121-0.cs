    using (SqlConnection connection = new SqlConnection(@"Data Source=(local);Integrated Security=True;Initial Catalog=DB_Name;")) {
      connection.Open();
      using (SqlCommand command = connection.CreateCommand()) {
        command.CommandText =
    @"SELECT s.name, o.name
    FROM sys.objects o WITH(NOLOCK)
    JOIN sys.schemas s WITH(NOLOCK)
      ON o.schema_id = s.schema_id
    WHERE o.is_ms_shipped = 0 AND RTRIM(o.type) = 'U'
    ORDER BY s.name ASC, o.name ASC";
        using (SqlDataReader reader = command.ExecuteReader()) {
          while (reader.Read()) {
            string schemaName = reader.GetString(0);
            string tableName = reader.GetString(1);
            
            // your code goes here...
          }
        }
      }
    }
