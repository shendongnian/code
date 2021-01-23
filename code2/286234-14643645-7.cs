            Database db = Factory.CreateDatabase("ConnectionString");
            try
            {
                using (IDbConnection w_connection = db.Connection)
                {
                    w_connection.Open();
                    IDbTransaction transation = w_connection.BeginTransaction();
                    IDbCommand dbcomand = db.CreateStoredProcCommand("INSERTTEST");
                    db.AddInParameter(dbcomand, "@ATTCH", DbType.Binary, bytes);
                    db.ExecuteNonQuery(dbcomand, transation);
                    transation.Commit();
                }
            }
            catch (Exception)
            {
            }
          }
