     public bool CopyDataTableToTable(DataTable dataTable, string tableName, bool deleteTable)
            {
                Boolean returnValue = true;
                if (sqlCeConnection.State == ConnectionState.Closed)
                    sqlCeConnection.Open();
    
                SqlCeTransaction transaction = sqlCeConnection.BeginTransaction();
                SqlCeCommand cmd = sqlCeConnection.CreateCommand();
                SqlCeResultSet rs = null;
                try
                {
                    if (deleteTable)
                    {
                        cmd.Transaction = transaction;
                        cmd.CommandText = "DELETE " + tableName;
                        cmd.ExecuteNonQuery();
                    }
    
                    cmd.CommandType = System.Data.CommandType.TableDirect;
                    cmd.CommandText = tableName;
                    rs = cmd.ExecuteResultSet(ResultSetOptions.Updatable);
    
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        SqlCeUpdatableRecord rec = rs.CreateRecord();
                        DataRow row = dataTable.Rows[i];
                        for (int k = 0; k < dataTable.Columns.Count - 1; k++)
                        {
                            rec.SetValue(k + 1, row[k]);
                        }
                        rs.Insert(rec);
                    }
                    transaction.Commit();
                }
    
                catch (Exception ex)
                {
                    returnValue = false;
                    transaction.Rollback();
                }
                finally
                {
                    rs.Close();
                    if (sqlCeConnection.State == ConnectionState.Open)
                        sqlCeConnection.Close();
    
                }
                return returnValue;
            }
