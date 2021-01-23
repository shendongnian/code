    public static Disposable GetDisposable(bool error)
    {
        if (error)
            throw new Exception("Error!");
        return new Disposable();
    }
