       SqlDatabase database = new SqlDatabase(connectionString);
       try {
          using (DbCommand command = database.GetStoredProcCommand(storedProcedureName)) {
             // Create parameters from myObject
            foreach (MyObject myObject in myObjectCollection)
            { 
                 // Add parameters to the command object         
                 database.ExecuteNonQuery (command);
           }
          } 
       } finally {
          if (database != null) {
             // Do whatever is necessary here to explicitly close the connection to the database
          }
       }
