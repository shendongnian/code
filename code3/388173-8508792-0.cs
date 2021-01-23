    class MyConnectionProvider : DriverConnectionProvider
    {
        public override IDbConnection GetConnection()
        {
            var connection = base.GetConnection();
            byte[] cooky;
            // TODO: authenticate
            return new MyConnectionWrapper(connection, cooky);
        }
        public override void CloseConnection(IDbConnection conn)
        {
            var myConn = conn as MyConnectionWrapper;
            if (myConn != null)
            {
                // TODO: deregister with myConn.Cooky;
            }
            base.CloseConnection(conn);
        }
    }
