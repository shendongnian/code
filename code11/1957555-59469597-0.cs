    public class Database
    {
            public string executeScaler(string commandText, bool isStoredProcedure, Dictionary<string, object> dictParams = null)
            {
                string result = "";
                DataTable dt = new DataTable();
                SqlConnection con = ConnectionStrings.GetConnection();
                SqlCommand cmd = new SqlCommand(commandText, con);
    
                if (isStoredProcedure)
                    cmd.CommandType = CommandType.StoredProcedure;
    
                if (dictParams != null)
                    foreach (KeyValuePair<string, object> rec in dictParams)
                        cmd.Parameters.AddWithValue("@" + rec.Key, rec.Value);
    
                try
                {
                    result = Convert.ToString(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
    
                return result;
            }
    }
