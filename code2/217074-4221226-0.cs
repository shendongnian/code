    DBHandle GetDB()
    {
        using( var db = DatabaseObj.GetHandle() )
        {
            db.Open();
            return db;
        }
    }
