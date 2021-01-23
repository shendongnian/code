    //public static void ExecuteInTransaction(Subtext.Scripting.SqlScriptRunner srScriptRunner)
            public override void ExecuteInTransaction(string strSQL)
            {
    
                System.Data.Odbc.OdbcTransaction trnTransaction = null;
    
                try
                {
    
    
                    System.Threading.Monitor.Enter(m_SqlConnection);
                    if (isDataBaseConnectionOpen() == false)
                        OpenSQLConnection();
    
                    trnTransaction = m_SqlConnection.BeginTransaction();
    
                    try
                    {
                        /*
                        foreach (Subtext.Scripting.Script scThisScript in srScriptRunner.ScriptCollection)
                        {
                            System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand(scThisScript.ScriptText, m_sqlConnection, trnTransaction);
                            cmd.ExecuteNonQuery();
                        }
                        */
                        
                        // pfff, mono C# compiler problem...
                        // System.Data.Odbc.OdbcCommand cmd = new System.Data.Odbc.OdbcCommand(strSQL, m_SqlConnection, trnTransaction);
                        System.Data.Odbc.OdbcCommand cmd = this.m_SqlConnection.CreateCommand();
                        cmd.CommandText = strSQL;
                        
                        cmd.ExecuteNonQuery();
    
                        trnTransaction.Commit();
                    } // End Try
                    catch (System.Data.Odbc.OdbcException exSQLerror)
                    {
                        Log(strSQL);
                        Log(exSQLerror.Message);
                        Log(exSQLerror.StackTrace);
                        trnTransaction.Rollback();
                    } // End Catch
                } // End Try
                catch (Exception ex)
                {
                    Log(strSQL);
                    Log(ex.Message);
                    Log(ex.StackTrace);
                } // End Catch
                finally
                {
                    strSQL = null;
                    if(m_SqlConnection.State != System.Data.ConnectionState.Closed)
                        m_SqlConnection.Close();
                    System.Threading.Monitor.Exit(m_SqlConnection);
                } // End Finally
    
    
            } // End Sub ExecuteInTransaction
