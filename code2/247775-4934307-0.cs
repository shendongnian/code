    db.BeginTransaction("myTransaction");
    try
    {
        // all your code here.  If anything goes awry, throw an exception
        // all good, commit it.
        db.CommitTransaction();
    }
    catch(Exception e)
    {
        // undo everything we just did
        db.RollbackTransaction();
    }
