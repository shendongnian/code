    using System.Data.SQLite;
    using System.Data.Common;
    
    
    SQLiteConnection db = new SQLiteConnection("Data Source=C:\LocalFolder\FooBar.db;FailIfMissing=True;");
    db.Open();
    using (SQLiteCommand comm=db.CreateCommand()) {
      comm.CommandText = requete_sql;
      IDataReader dr=comm.ExecuteReader();
      while (dr.Read())
      {
        //...
      }
    }
