      public static class DbConnectionFactory {
        public static IDbConnection Create(string connectionString) {
          var connection = new OracleConnection(connectionString);
          connection.Open();
    
          return connection;
        }
      }
      const string dropTableCustomers = "DROP TABLE CUSTOMERS";
      const string createTableCustomers = @"    
        CREATE TABLE CUSTOMERS (
        ID INT NOT NULL PRIMARY KEY,
        NAME VARCHAR(12) NOT NULL,
        AGE INT,
        ADDRESS VARCHAR(12))";
      const string insertCustomerMark = "INSERT INTO CUSTOMERS (ID,NAME,AGE,ADDRESS) VALUES (1, 'Mark', 28, 'NY')";
      const string insertCustomerJohn = "INSERT INTO CUSTOMERS (ID,NAME,AGE,ADDRESS) VALUES (2, 'John', 39, 'LA')";
      using (var connection = DbConnectionFactory.Create("User Id=SYSTEM;Password=mw;Data Source=SampleDataSource"))
      using (var transaction = connection.BeginTransaction()) {
        
        connection.Execute(dropTableCustomers);
        connection.Execute(createTableCustomers);
        connection.Execute(insertCustomerMark);
        connection.Execute(insertCustomerJohn);
        transaction.Commit();
      }
