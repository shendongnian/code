    DBstructure dbconn = new DBstructure();
    dbconn.Database.Connection.ConnectionString = connectionString //depends on your DB
    dbconn.Bars.Add(bar);
    dbconn.Database.Connection.Open();
    dbconn.SaveChanges();
    dbconn.Database.Connection.Close();
