      string sql = "INSERT INTO Customers (CustomerName) Values (@CustomerName);";
      using (var connection = new SqlConnection("")) {
        connection.Open();
        var affectedRows = await connection.ExecuteAsync(sql,
          new[] {
            new {CustomerName = "John"},
            new {CustomerName = "Andy"},
            new {CustomerName = "Allan"}
          }
        );
      }
