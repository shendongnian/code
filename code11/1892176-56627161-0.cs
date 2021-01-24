        ...
        using (var command = new SqlCommand(sqlSelect, SqlConnector.getConnection())) {
          // Redundant, can be dropped
          command.Connection = SqlConnector.getConnection();
          using (var reader = command.ExecuteReader()) {
            string key = Convert.ToString(reader[0]);
            string value = Convert.ToString(reader[1]);
            if (rowAndTables.TryGetValue(key, out var list))  
              list.Add(value);
            else 
              rowAndTables.Add(key, new List<string>() {value});  
          }
        }
