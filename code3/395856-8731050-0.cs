    private DataTable miDatatable(string sqlQuery)
            {
                using (OleDbConnection connDB = new OleDbConnection(connString))
                {
                    OleDbDataAdapter dAdapter;
                    OleDbCommandBuilder cBuilder;
                    OleDbCommand command = new OleDbCommand();
                    DataTable dTable = new DataTable();
                    OleDbTransaction trans = null;
    
                    try
                    {
                        connDB.Open();
                        trans = connDB.BeginTransaction(IsolationLevel.ReadCommitted);
    
                        command.Connection = connDB;
                        command.Transaction = trans;
                        command.CommandText = sqlQuery;
    
                        dAdapter = new OleDbDataAdapter(sqlQuery, connDB);
                        cBuilder = new OleDbCommandBuilder(dAdapter);
    
                        dAdapter.SelectCommand.Transaction = trans;
                        dAdapter.Fill(dTable);
                        trans.Commit();
                    }
    
                    catch 
                    {
                        try
                        {
                            trans.Rollback();
                        }
                        catch { }
                    }
    
                    return dTable;
                }
            }
