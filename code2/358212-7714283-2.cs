    // this.SaveChanges(() => article.Authors.Remove(author));
    protected void SaveChanges(Action rollback)
    {
        try { this._db.SaveChanges(); }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e);
            rollback();
        }
    }
    // Overload to support rollback with an argument
    // this.SaveChanges(article.Authors.Remove, author);
    protected void SaveChanges<T>(Action<T> rollback, T arg)
    {
        try { this._db.SaveChanges(); }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e);
            rollback(arg);
        }
    }
