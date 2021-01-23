    public DataTable CheckDB()
    {
        DataTable result = new DataTable();
        try
        {
            string connectionString = 
              string.Format("server={0};database={1};user id={2};pwd={3}"
                            "A-63A9D4D7E7834\SECOND", "master", "sa", "two"); 
            string checkQuery = "SELECT * FROM sys.databases WHERE name = 'my_db'";
  
            using(SqlConnection _con = new SqlConnection(connectionString))
            using(SqlCommand _cmd = new SqlCommand(checkQuery, _con))
            {
                SqlDataAdapter DBcreatingAdaptor = new SqlDataAdapter(_cmd);
                DBcreatingAdaptor.Fill(_result);
            }
        }//try
        catch (SqlException e)
        {
             // you can inspect the SqlException.Errors collection and 
             // get **VERY** detailed description of what went wrong,
             // including explicit SQL Server error codes which are 
             // unique to each error
        }//catch
        return result;
    }//check db
