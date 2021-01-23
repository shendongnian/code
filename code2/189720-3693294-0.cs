    public class SybaseDBHelper : ISybaseDBHelper
        {
            private AseConnection conn;
            private AseCommand cmd;
            private AseDataAdapter adapter;
            private DataSet outDS;
            protected static readonly ILog _logger = LogManager.GetLogger(typeof (SybaseDBHelper));
     
            #region InsertData
            public int InsertDataUsingStoredProcedure(string storedProcedureName, DatabaseEnum dbName, List<AseParameter> parameters)
            {
                var connFactory = new ConnectionFactory();
                int _errorCode = 0;
                string connectionString = connFactory.GetConnectionString(dbName);
                using (conn = connFactory.GetAseConnectionString(connectionString))
                {
                    try
                    {
                        conn.Open();
                        if (conn.State == ConnectionState.Open)
                        {
                            using (cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = storedProcedureName;
                                if (parameters != null )
                                {
                                    foreach (AseParameter param in parameters)
                                    {
                                        cmd.Parameters.Add(param);
                                    }
                                }
                               _errorCode = cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (AseException ex)
                    {
                        _logger.ErrorFormat("Error Inserting Data into Database {0}", ex);
                        throw;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                return _errorCode;
            }
     
            #endregion
     
            #region IDisposable Members
     
            public void Dispose()
            {
                Dispose(true);
            }
     
            protected virtual void Dispose(bool disposing)
            {
                if (disposing)
                {
                    conn.Dispose();
                    conn = null;
                    GC.SuppressFinalize(this);
                }
            }
     
            #endregion
      
