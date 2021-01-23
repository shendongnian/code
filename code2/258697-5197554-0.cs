    static public void UpdateDB(string strSql, DataSet ds, string tablename)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(strSql, connection);
            try
            {
               connection.Open();
               cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
               // error hanlding code here
            }
            finally
            {
              cn.Close();
            }
                   }
