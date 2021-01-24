    using (connection)  
    {  
      // Create a DataTable with the modified rows.  
      DataTable addedStudents = StudentsDataTable.GetChanges(DataRowState.Added);  
    
      // Define the INSERT-SELECT statement.  
      string sqlInsert =  
          "INSERT INTO dbo.Students (xxx, yyy)"  
          + " SELECT s.xxx, s.yyy"  
          + " FROM @tvpStudents AS s;"  
    
      // Configure the command and parameter.  
      SqlCommand insertCommand = new SqlCommand(sqlInsert, connection);  
      SqlParameter tvpParam = insertCommand.Parameters.AddWithValue("@tvpStudents", addedStudents);  
      tvpParam.SqlDbType = SqlDbType.Structured;  
      tvpParam.TypeName = "dbo.StudentTableType";  
    
      // Execute the command.  
      insertCommand.ExecuteNonQuery();  
    }  
