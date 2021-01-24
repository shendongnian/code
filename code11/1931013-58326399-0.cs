     public void OpenConnection(SqlConnection DBConnection)
            {
                try
                {       
                        DBConnection.ConnectionString = @"Server = " + Server + "; Database = " + DataBase + "; User ID = Username; Password = Password; Trusted_Connection = False;Max Pool Size=1000";
    
    
                        DBConnection.Open();
                        bIsConnected = true;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
    		
    
            public void FillDataTable(DataTable dataTable, SqlConnection DBConnection, ref string sql)
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, DBConnection);
    
                try
                {
                    da.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    throw new Exception(sql, ex);
                }
            }
    		
    		public static MY_TB.MY_TBDataTable GetMyTB()
            {
                try
                {
                    string sql = String.Format("SELECT * FROM MY_TB");
    
                    SqlConnection sql = OpenConnection(sql);
                    MY_TB tb = new MY_TB();
                    db.FillDataTable(tb._MY_TB, ref sql);
    
                    return tb._MY_TB;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally { mb.db.CloseConnection(); }
            }
		
		
