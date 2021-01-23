    SqlConnection DbConn = new SqlConnection(yourConnectionString);
    SqlCommand GetDataFile = new SqlCommand();
    GetDataFile.Connection = DbConn;
    GetDataFile.CommandText = "select physical_name from sys.database_files where type = 0";
    
    try
    {
        DbConn.Open();
        string YourDataFile = (string) GetDataFile.ExecuteScalar();
        DbConn.Close();
    }
    catch (Exception ex)
    {
        DbConn.Dispose();
    }
