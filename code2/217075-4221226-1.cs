    DBHandle GetDB()
    {
        var db = DatabaseObj.GetHandle();
        try
        {
          db.Open();
          return db;
        }
        finally
        {
            if(db != null)//not included if db is a value-type
              ((IDisposable)db).Dispose();
        }
    }
