    public static Disposable GetDisposable(bool error)
    {
        var obj = new Disposable();
        
        try
        {
            if (error)
                throw new Exception("Error!");
            return obj;
        }
        catch
        {
            obj.Dispose();
            throw;
        }
    }
