        public override System.Data.DataTable GetDataTable(string strSQL)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            using (System.Data.IDbConnection idb = GetConnection())
            {
                
                lock (idb)
                {
                    try
                    {
                        
                        using (System.Data.OleDb.OleDbDataAdapter daQueryTable = new System.Data.OleDb.OleDbDataAdapter(strSQL, (System.Data.OleDb.OleDbConnection) idb))
                        {
                            daQueryTable.Fill(dt);
                        } // End Using daQueryTable
                    } // End Try
                    catch (Exception ex)
                    {
                        Log("cOleDB.GetDataTable(string strSQL)", ex, strSQL);
                    } // End Catch
                    finally
                    {
                        if (idb.State != System.Data.ConnectionState.Closed)
                            idb.Close();
                    } // End Finally
                } // End Lock idb
            } // End Using idb
            return dt;
        } // End Function GetDataTable
        public System.Data.IDbConnection GetConnection()
        {
            System.Data.OleDb.OleDbConnection oledbc= new System.Data.OleDb.OleDbConnection(m_ConnectionString.ConnectionString);
            return oledbc;
        }
