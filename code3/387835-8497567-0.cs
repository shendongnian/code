    private DataTable BindData()
            {
                using (var conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\YOURDB.mdb; PersSecurity Info=False;")) /your connectionsting
                {
                    using (var dAd = new OleDbDataAdapter("select column1 from Table ", conn)) //select query from your DB
                    {
                       
                        var dSet = new DataTable();
                        try
                        {
                            conn.Open();
    
                            dAd.Fill(dSet);
    
                            return dSet;
    
                        }
                        catch
                        {
                            throw;
                        }
                        finally
                        {
                            if (conn.State == ConnectionState.Open) conn.Close();
                        }
                    }
                }
            }
