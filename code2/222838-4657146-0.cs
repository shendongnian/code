    SqlCeConnection sqlConnection1= new SqlCeConnection();
    sqlConnection1.ConnectionString = "Data Source = C:\\Users\\Tim\\Documents\\Visual Studio 2010\\Projects\\Dispatch POS\\Dispatch POS\\GhsDB.sdf";
    
    System.Data.SqlServerCe.SqlCeCommand cmd = System.Data.SqlServerCe.SqlCeCommand;
    cmd.CommandType = System.Data.CommandType.Text;
    cmd.CommandText = "INSERT [Employee Table] (SSN, FirstName) VALUES ('555-23-4322', 'Tim')";
    cmd.Connection = sqlConnection1;
    
    sqlConnection1.Open();
    cmd.ExecuteNonQuery();
    sqlConnection1.Close();
