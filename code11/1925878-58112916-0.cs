     internal static OracleDatabase ServerConnection()
            {
                try
                {
                    string connectionString = TNSORA.TnsNames();
    
                    OracleConnection connection = new OracleConnection(connectionString);
                    OracleDatabase oracleDatabase = new OracleDatabase(connection);
                    return oracleDatabase;
                }
                catch {return null;}
                
            }
    
    internal static string TnsNames()
            {
    //TODO get your TNS from your environment variable, if you have more you have to select by code which is the correct one
            }
