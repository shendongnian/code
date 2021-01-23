    protected void SaveChanges<T, TArg>(T mlaObject, TArg arg, Action undoFunction)
        where T : WebObject
    {
        try { this._db.SaveChanges(); }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e);
            undoFunction(arg);
        }
    }
