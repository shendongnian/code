    namespace MyNameSpace
    {
       public class MyDbConnection : System.Data.IDbConnection
       {
          private readonly System.Data.IDbConnection _sqlConnection;
    
          public MyDbConnection()
          {
              var sqlConnection = new SqlConnection;
              // Could probably delay the assignment to when Open() is called
              sqlConnection.AccessToken = "Hello World";
              _sqlConnection = sqlConnection;
          }
    
          public string ConnectionString
          {
              get => _sqlConnection.ConnectionString;
              set => _sqlConnection.ConnectionString = value;
          }
    
          public int ConnectionTimeout => _sqlConnection.ConnectionTimeout;
          public string Database => _sqlConnection.Database;
          public ConnectionState State => _sqlConnection.State;
          public IDbTransaction BeginTransaction() => _sqlConnection.BeginTransaction();
          public IDbTransaction BeginTransaction(IsolationLevel il) => _sqlConnection.BeginTransaction(il);
          public void ChangeDatabase(string databaseName) => _sqlConnection.ChangeDatabase(databaseName);
          public void Close() => _sqlConnection.Close();
          public IDbCommand CreateCommand() => _sqlConnection.CreateCommand();
          public void Open() => _sqlConnection.Open();
          public void Dispose() => _sqlConnection.Dispose();
       }
    }
