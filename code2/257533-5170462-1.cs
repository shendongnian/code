    var server = new Server(serverName); // Can use overload that specifies 
    
    foreach (Database db in server.Databases)
    {
         if (db.Name.ToLower().Contains(testDatabaseIdentifier))
         {
              databasesToDelete.Add(db.Name);
         }
    }
    databasesToDelete.ForEach(x =>
    {
         Database db = new Database(server, x);
         db.Refresh();
         db.Drop();
    });
