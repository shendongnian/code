    interface IConnectable {
        IConnection Connect();
    }
    
    interface IConnection {
        IResultSet ExecuteQuery(string query);
    }
