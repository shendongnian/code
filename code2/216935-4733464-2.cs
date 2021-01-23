    try
    {
        Throw();
    }
    catch (Exception ex)
    {
        throw ex;
    }
    // ... 
    public void Throw()
    {
        int a = 10/0;
    }
