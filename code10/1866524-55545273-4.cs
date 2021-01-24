    public void ThrowException()
    {
        try
        {
            MakeDatabaseCall();
        }
        catch (Exception e)
        {
            throw new Exception("Uh oh!", e);
        }
    }
    public void MakeDatabaseCall()
    {
        throw new SqlException();
    }
