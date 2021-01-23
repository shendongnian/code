    protected void SaveChanges<T,U>(T mlaObject, Action<U> action, U arg)
        where T : WebObject
    {
        try { this._db.SaveChanges(); }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e);
            action(arg);
        }
    }
