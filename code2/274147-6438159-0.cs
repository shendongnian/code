      public void CloseDB()
      {
        Connection.Close();               //Connection is a property(of type SqliteConnection) of my object
        FileStream.HandleTracker.Clear(); //This here is the fix
      } 
