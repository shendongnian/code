         public class OracleDatabase : Database
         {
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
        }
       public class SQLDatabase : Database
       {
          public override IDbConnection CreateConnection()
          {
              return new SqlConnection(ConnectionString);
          }
          public override IDbCommand CreateCommand()
          {
              return new SqlCommand();
          }
          public override IDbConnection CreateOpenConnection()
          {
              SqlConnection connection = (SqlConnection)CreateConnection();
              connection.Open();
              return connection;
          }
          public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
          {
              SqlCommand command = (SqlCommand)CreateCommand();
              command.CommandText = commandText;
              command.Connection = (SqlConnection)connection;
              command.CommandType = CommandType.Text;
              return command;
          }
          public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
          {
              SqlCommand command = (SqlCommand)CreateCommand();
              command.CommandText = procName;
              command.Connection = (SqlConnection)connection;
              command.CommandType = CommandType.StoredProcedure;
              return command;
            }
         }
