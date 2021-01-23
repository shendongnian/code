    ServerConnection connection = new ServerConnection(serverName, userName, password);
    Server sqlServer = new Server(connection);
    Database newDB = new Database(sqlServer, databaseName);
    try
    {
       newDB.Create();
    } 
    catch(Exception exc) 
    {
       string msg1 = exc.Message;
       if(exc.InnerException != null)
       {
           string msg2 = exc.InnerException.Message;
           if(exc.InnerException.InnerException != null)
           {
               string msg3 = exc.InnerException.InnerExceptionMessage;
           }
       }
    }
