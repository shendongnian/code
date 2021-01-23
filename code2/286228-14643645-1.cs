        public override IDbConnection CreateConnection()
        {
            return new OracleConnection(ConnectionString);
        }
        public override IDbCommand CreateCommand()
        {
            return new OracleCommand();
        }
        public override IDbConnection CreateOpenConnection()
        {
            OracleConnection connection = (OracleConnection)CreateConnection();
            connection.Open();
            return connection;
        }
        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            OracleCommand command = (OracleCommand)CreateCommand();
            command.CommandText = commandText;
            command.Connection = (OracleConnection)connection;
            command.CommandType = CommandType.Text;
            return command;
        }
