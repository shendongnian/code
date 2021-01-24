    using (var transactionSql = connection.BeginTransaction())
    {
          
      try
      {
          // Updating table1
          var commandUpd1 = new SqlCommand(query, connection, transactionSql);
          commandUpd1.ExecuteNonQuery();
          // Inserting table2
          var commandInsert1 = new SqlCommand(query2, connection, transactionSql);
          commandInsert1.ExecuteNonQuery();
          using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transactionSql))
          { 
             // My bulk on table3
             bulkCopy.WriteToServer(dataTable);
          }
          // Updating table1
          var commandUpd2 = new SqlCommand(query3, connection, transactionSql);
          commandUpd2.ExecuteNonQuery();
          // Inserting table2
          var commandInsert3 = new SqlCommand(query4, connection, transactionSql);
          commandInsert3.ExecuteNonQuery();
          transactionSql.Commit();  // Timeout   
     }
     catch (Exception ex)
     {
          transactionSql.Rollback();  //Zombie error
          throw ex;
     }
   
    }
