    public Boolean Login(string strUserName, string strPassword)
            {
                SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection();
                DataSet ds = null;
                SqlDataAdapter da = null;
    
                sqlConn.ConnectionString = strConnString;
    
                try
                {
                    blnCMTError = false;
                    sqlConn.Open();
    
                    ds = new DataSet();
                    da = new SqlDataAdapter("select iuserid from tbl_Table where vchusername = @vchUserName and vchpassword = @vchPassword", sqlConn);
    
                    da.SelectCommand.Parameters.AddWithValue("@vchUserName", strUserName);
                    da.SelectCommand.Parameters.AddWithValue("@vchPassword", strPassword);
    
                    da.SelectCommand.CommandTimeout = 30;
                    da.Fill(ds);
    
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        iUserId = (int)ds.Tables[0].Rows[0]["iuserid"];
                    }
                }
                catch (Exception ex)
                {
                    blnError = true;
                    Log("Login: " + ex.Message);
                }
                finally
                {
                    if (sqlConn.State != ConnectionState.Closed)
                        sqlConn.Close();
                    if (da != null)
                        da.Dispose();
                    if (ds != null)
                        ds.Dispose();
                }
                if (blnError)
                    return false;
                if (iUserId > 0)
                    return true;
                return false;
            }
