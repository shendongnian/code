        Object executeLock = new Object();
        
        private IDataReader ExecuteThreadSafe(IDbCommand sqlCommand)
        {
            lock (executeLock)
            {
                return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
