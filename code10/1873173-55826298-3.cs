    public void M()
    {
        using (CreateThing())
        {
        }
    }
    
    public IDisposable CreateThing() => null;
