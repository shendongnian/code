       string connectionString = "Server=tcp:XXXXX.database.windows.net;Database=XXXXXX;User ID=XXXXXX;Password=XXXXX;Trusted_Connection=False;Encrypt=True;trustservercertificate=true";
       SqlConnection connection = new SqlConnection(connectionString);
       // do not explicitly open connection, it will be opened when Server is initialized
       // connection.Open();
       ServerConnection serverConnection = new ServerConnection(connection);
       Server server = new Server(serverConnection);
   
       // after this line, the default database will be switched to Master
       Database database = server.Databases["MyDatabase"];
       
       // you can still use this database object and server connection to 
       // do certain things against this database, like adding database roles 
       // and users      
       DatabaseRole role = new DatabaseRole(database, "NewRole");
       role.Create();
       // if you want to execute a script against this database, you have to open 
       // another connection and re-initiliaze the server object
       server.ConnectionContext.Disconnect();
       connection = new SqlConnection(connectionString);
       serverConnection = new ServerConnection(connection);
       server = new Server(serverConnection);
       server.ConnectionContext.ExecuteNonQuery("CREATE TABLE New (NewId int)");
