    private DataTable GetDataTable()
        {
            try
            {
                string strQuery = "Your SQL Query";
                string strConnectionString ="Your Connection String";
                using (SqlConnection Connection = new SqlConnection(strConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(strQuery))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Connection = Connection;
                            da.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
