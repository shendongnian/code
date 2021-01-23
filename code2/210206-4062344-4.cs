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
                _con.Open();
                _cmd.ExecuteNonQuery();
                _con.Close();
            }
        }//try
        catch (SqlException e)
        {
           // check the detailed errors 
           // error.Number = 1801 : "database already exists" (choose another name)
           // error.Number = 102: invalid syntax (probably invalid db name)
           foreach (SqlError error in e.Errors)
           {
              string msg = string.Format("{0}/{1}: {2}", error.Number, error.Class, error.Message);
           }
        }//catch
    }//make db
