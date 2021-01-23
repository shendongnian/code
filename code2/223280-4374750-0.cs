    Server server = new Server(@".\SQLEXPRESS");
    Database db = server.Databases["DBName"];
    foreach(Table table in db.Tables)
    {
         foreach (Index index in table.Indexes)
         {
         }
    }
