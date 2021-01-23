csharp
  using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(30));
  using SqlConnection connection = this.GetConnection();
  await connection.OpenAsync(timeout.Token);
  using SqlCommand command = connection.CreateCommand();
  command.CommandType = CommandType.StoredProcedure;
  command.CommandText = "Mycommand";
  IEnumerable<SqlDataRecord> records = // ...
  SqlParameter parameter = command.Parameters.Add("@MyObjects", SqlDbType.Structured);
  parameter.TypeName = "MyCustomTableType";
  parameter.Value = records;
  await command.ExecuteNonQueryAsync(timeout.Token);
Example using a **DataTable**:
csharp
  // Create a DataTable with the modified rows.  
  DataTable addedCategories = CategoriesDataTable.GetChanges(DataRowState.Added);  
  // Configure the SqlCommand and SqlParameter.  
  SqlCommand insertCommand = new SqlCommand("usp_InsertCategories", connection);  
  insertCommand.CommandType = CommandType.StoredProcedure;  
  SqlParameter tvpParam = insertCommand.Parameters.AddWithValue("@tvpNewCategories", addedCategories);  
  tvpParam.SqlDbType = SqlDbType.Structured;  
  // Execute the command.  
  insertCommand.ExecuteNonQuery(); 
Example using **DbDataReader**:
csharp
 // Assumes connection is an open SqlConnection.  
 // Retrieve data from Oracle.  
 OracleCommand selectCommand = new OracleCommand(  
     "Select CategoryID, CategoryName FROM Categories;",  
     oracleConnection);  
 OracleDataReader oracleReader = selectCommand.ExecuteReader(  
     CommandBehavior.CloseConnection);  
  
  // Configure the SqlCommand and table-valued parameter.  
  SqlCommand insertCommand = new SqlCommand(  
      "usp_InsertCategories", connection);  
  insertCommand.CommandType = CommandType.StoredProcedure;  
  SqlParameter tvpParam =  
      insertCommand.Parameters.AddWithValue(  
      "@tvpNewCategories", oracleReader);  
  tvpParam.SqlDbType = SqlDbType.Structured;  
  
  // Execute the command.  
  insertCommand.ExecuteNonQuery(); 
