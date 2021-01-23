    public void MakeDB()
    {
        try
        {
            string connectionString = 
              string.Format("server={0};database={1};user id={2};pwd={3}"
                            "A-63A9D4D7E7834\SECOND", "master", "sa", "two"); 
            string createDBQuery = "CREATE DATABASE my_db";
            using(SqlConnection _con = new SqlConnection(connectionString))
            using(SqlCommand _cmd = new SqlCommand(createDBQuery, _con))
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
