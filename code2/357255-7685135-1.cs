    [Export(typeof(IRepository))]
    public IRepository Repository
    {
        get { return CreateRepository(); }
    }
