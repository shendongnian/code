    public bool TrySomething(out object destination)
    {
        try
        {
            destination = DoSomething();
            return true;
        }
        catch
        {}
        return false;
    }
