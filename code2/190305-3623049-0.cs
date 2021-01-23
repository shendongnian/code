    public void Dispose()
    {
        if (Next() != null)
        {
            Next().Dispose();
        }
    }
