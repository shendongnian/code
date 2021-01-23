    [Dependency]
    public IMyService Service { get; set; }
    
    protected void OnObjectCreating(...)
    {
       e.ObjectInstance = Service;
    }
