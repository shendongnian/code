    public void CheckDB()
    {
        try
        {
            string connectionString = 
              string.Format("server={0};database={1};user id={2};pwd={3}"
                            "A-63A9D4D7E7834\SECOND", "master", "sa", "two"); 
            string checkQuery = "SELECT * FROM sys.databases WHERE name = 'my_db'";
  
            using(SqlConnection connection = new SqlConnection(connectionString))
            using(SqlCommand _cmd = new SqlCommand(checkQuery, connection))
            {
                SqlDataAdapter DBcreatingAdaptor = new SqlDataAdapter(_cmd);
                DataTable databases = new DataTable();
                DBcreatingAdaptor.Fill(databases);
    
                GridView1.DataSource = databases;
                GridView1.DataBind();   // do n
            }
        }//try
        catch (SqlException e)
        {
             // you can inspect the SqlException.Errors collection and 
             // get **VERY** detailed description of what went wrong,
             // including explicit SQL Server error codes which are 
             // unique to each error
        }//catch
    }//check db
    public void MakeDB()
    {
        try
        {
            string connectionString = 
              string.Format("server={0};database={1};user id={2};pwd={3}"
                            "A-63A9D4D7E7834\SECOND", "master", "sa", "two"); 
            string createDBQuery = "CREATE DATABASE my_db";
            using(SqlConnection connection = new SqlConnection(connectionString))
            using(SqlCommand _cmd = new SqlCommand(createDBQuery, connection))
            { 
                connection.Open();
                _cmd.ExecuteNonQuery();
                connection.Close();
            }
        }//try
        catch (SqlException e)
        {
            // AGAIN: inspect the SqlException, return error, but DO NOT 
            // write out to the response directly!!
        }//catch
    }//make db
