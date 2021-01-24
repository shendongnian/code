    using (connection)  
    { 
      // Create a DataTable with the modified rows.  
      DataTable addedCategories = CategoriesDataTable.GetChanges(DataRowState.Added);  
    
      // Define the INSERT-SELECT statement.  
      string sqlInsert =   
          "INSERT INTO dbo.Categories (CategoryID, CategoryName)"  
          + " SELECT nc.CategoryID, nc.CategoryName"  
          + " FROM @tvpNewCategories AS nc;"  
    
      // Configure the command and parameter.  
      SqlCommand insertCommand = new SqlCommand(sqlInsert, connection);  
      SqlParameter tvpParam = insertCommand.Parameters.AddWithValue("@tvpNewCategories", addedCategories);  
      tvpParam.SqlDbType = SqlDbType.Structured;  
      tvpParam.TypeName = "dbo.CategoryTableType";  
    
      // Execute the command.  
      insertCommand.ExecuteNonQuery();  
    }  
