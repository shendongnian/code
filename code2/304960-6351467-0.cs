    protected List<Exception> Exceptions = new List<Exception>();
    
    protected void SomeMethod()
    {
        try
        {
            ...
        }
        catch(Exception e)
        {
            this.Exceptions.Add(e);
        }
    }
