Microsoft.SqlServer.Management.Common.ConnectionFailureException was unhandled
  Message=Failed to connect to server .
  Source=Microsoft.SqlServer.Smo
  StackTrace:
       at Microsoft.SqlServer.Management.Smo.DatabaseCollection.get_Item(String name)
       InnerException: System.Data.SqlClient.SqlException
       Message=Login failed for user 'XXXXXXXX'.
       This session has been assigned a tracing ID of 'XXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXX'.  Provide this tracing ID to customer support when you need assistance.
       Source=.Net SqlClient Data Provider
       ErrorCode=-2146232060
       Class=14
       LineNumber=65536
       Number=18456
       Procedure=""
       Server=tcp:XXXXXXXX.database.windows.net
       State=1
       StackTrace:
            at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection)
            at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning()
            at System.Data.SqlClient.TdsParser.Run(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj)
            at System.Data.SqlClient.SqlInternalConnectionTds.CompleteLogin(Boolean enlistOK)
            at System.Data.SqlClient.SqlInternalConnectionTds.AttemptOneLogin(ServerInfo serverInfo, String newPassword, Boolean ignoreSniOpenTimeout, TimeoutTimer timeout, SqlConnection owningObject)
            at System.Data.SqlClient.SqlInternalConnectionTds.LoginNoFailover(ServerInfo serverInfo, String newPassword, Boolean redirectedUserInstance, SqlConnection owningObject, SqlConnectionString connectionOptions, TimeoutTimer timeout)
            at System.Data.SqlClient.SqlInternalConnectionTds.OpenLoginEnlist(SqlConnection owningObject, TimeoutTimer timeout, SqlConnectionString connectionOptions, String newPassword, Boolean redirectedUserInstance)
            at System.Data.SqlClient.SqlInternalConnectionTds..ctor(DbConnectionPoolIdentity identity, SqlConnectionString connectionOptions, Object providerInfo, String newPassword, SqlConnection owningObject, Boolean redirectedUserInstance)
            at System.Data.SqlClient.SqlConnectionFactory.CreateConnection(DbConnectionOptions options, Object poolGroupProviderInfo, DbConnectionPool pool, DbConnection owningConnection)
            at System.Data.ProviderBase.DbConnectionFactory.CreatePooledConnection(DbConnection owningConnection, DbConnectionPool pool, DbConnectionOptions options)
            at System.Data.ProviderBase.DbConnectionPool.CreateObject(DbConnection owningObject)
            at System.Data.ProviderBase.DbConnectionPool.UserCreateRequest(DbConnection owningObject)
            at System.Data.ProviderBase.DbConnectionPool.GetConnection(DbConnection owningObject)
            at System.Data.ProviderBase.DbConnectionFactory.GetConnection(DbConnection owningConnection)
            at System.Data.ProviderBase.DbConnectionClosed.OpenConnection(DbConnection outerConnection, DbConnectionFactory connectionFactory)
            at System.Data.SqlClient.SqlConnection.Open()
            at Microsoft.SqlServer.Management.Common.ConnectionManager.InternalConnect(WindowsIdentity impersonatedIdentity)
            at Microsoft.SqlServer.Management.Common.ConnectionManager.Connect()
