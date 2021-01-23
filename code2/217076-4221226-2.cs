    DBHandle GetDB()
    {
        var db = DatabaseObj.GetHandle();
        try
        {
          db.Open();
          return db;
        }
        catch
        {
            if(db != null)
              ((IDisposable)db).Dispose();
            throw;
        }
    }
