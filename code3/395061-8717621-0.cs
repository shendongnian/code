            OdbcConnection odbcConn = new OdbcConnection(odbcConnString);//your odbc conn String
            odbcConn.Open();
            OdbcTransaction odbcTransStockList;//if you want to use transaction
            using (OdbcCommand odbcmdSelect = new OdbcCommand(strInsertStringAccess, odbcConn))//or if you are using SQL Server I am assuming it's Access
            {
                odbcmdInsert.CommandTimeout = 60;
                odbcTransStockList = odbcConn.BeginTransaction();
                odbcmdInsert.Transaction = odbcTransStockList;
                odbcmdInsert.CommandType = System.Data.CommandType.Text;
                try
                {
                    odbcmdInsert.ExecuteNonQuery();
                    odbcTransStockList.Commit();
                }
                catch (OdbcException odbcEx)
                {
                    Console.WriteLine(odbcEx.Message);
                }
            }
            ((IDisposable)odbcTransStockList).Dispose();
            ((IDisposable)odbcConn).Dispose();
        }
        catch (OdbcException odbcEx)
        {
            Console.WriteLine(odbcEx.Message);
        }
