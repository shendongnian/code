                using (OleDbCommand olecmdStkNames = new OleDbCommand(strSQL, oleconnStkNames))
                {
                    olecmdStkNames.CommandTimeout = 60;
                    oletransStockList = oleconnStkNames.BeginTransaction();
                    olecmdStkNames.Transaction = oletransStockList;
                    olecmdStkNames.CommandType = System.Data.CommandType.Text;
                    try
                    {
                        intRecordsAffected = olecmdStkNames.ExecuteNonQuery();
                        oletransStockList.Commit();
                       }
                    catch (OleDbException oledbExInsert_Update)
                    {
                        oletransStockList.Rollback();
                        Console.WriteLine(oledbExInsert_Update.Message);
                    }
                    ((IDisposable)oletransStockList).Dispose();
                }
