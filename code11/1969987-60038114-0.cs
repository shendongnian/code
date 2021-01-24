    public interface IDataAccessContext {
        DbCommand GetCommand(bool isTransaction, IsolationLevel isolationLevel);
        int ExecuteNonQuery(DbCommand objDbCommand, string textOrSpName, CommandType commandType);
        int ExecuteNonQuery(DbCommand objDbCommand);
        DbDataReader ExecuteReader(DbCommand objDbCommand, string textOrSpName, CommandType commandType);
        DbDataReader ExecuteReader(DbCommand objDbCommand);
        Dispose(DbCommand objDbCommand);
        //...
    }
    
