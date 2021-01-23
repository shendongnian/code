    protected void SaveChanges<T>(T mlaObject, Action<T> rollback)
        where T : WebObject
    {
        try { this._db.SaveChanges(); }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e);
            rollback(arg);
        }
    }
