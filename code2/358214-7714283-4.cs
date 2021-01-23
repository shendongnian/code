    // this.SaveChanges(
    //     () => article.Authors.Remove(author),
    //     () => article.RelatedTags.Remove(tag));
    protected void SaveChanges(params Action[] rollbacks)
    {
        try { this._db.SaveChanges(); }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e);
            foreach (var rollback in rollbacks) rollback();
        }
    }
    // Overload to support rollback with an argument
    // this.SaveChanges(
    //     author,
    //     article.Authors.Remove,
    //     authorCache.Remove);
    protected void SaveChanges<T>(T arg, params Action<T>[] rollbacks)
    {
        try { this._db.SaveChanges(); }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e);
            foreach (var rollback in rollbacks) rollback(arg);
        }
    }
