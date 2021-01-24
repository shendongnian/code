        ...
        using (var command = new SqlCommand(sqlSelect, SqlConnector.getConnection())) {
          // Redundant, can be dropped
          command.Connection = SqlConnector.getConnection();
          using (var reader = command.ExecuteReader()) {
            //TODO: check are the key and value are correct ones 
            string key = Convert.ToString(reader[0]);
            string value = Convert.ToString(reader[1]);
            // Do we have the key (and corresponding list) in the dictionary?
            if (rowAndTables.TryGetValue(key, out var list))  
              // yes - we should add the value to the existing list 
              list.Add(value); 
            else 
              // no - we have to create key and list with value 
              rowAndTables.Add(key, new List<string>() {value}); 
          }
        }
