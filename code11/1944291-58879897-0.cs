    using(SqlConnection connection = new 
     SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ConnectionString))
     {
            connection.Open();
            string sql =  "INSERT INTO Table(id,name,test) 
            VALUES(@param1,@param2,@param3)";
            using(SqlCommand cmd = new SqlCommand(sql,connection)) 
            {
                  cmd.Parameters.Add("@param1", SqlDbType.Int).value = val;  
                  cmd.Parameters.Add("@param2", SqlDbType.Varchar, 50).value = Name;
                  cmd.Parameters.Add("@param3", SqlDbType.Varchar, 50).value = Test;
                  cmd.CommandType = CommandType.Text;
                  cmd.ExecuteNonQuery(); 
            }
 }
