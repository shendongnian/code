    private SomeRepositoryType _someRepository
    public SomeRepositoryType SomeRepository
    {
        get { _someRepository ?? (_someRepository = new SomeRepositoryType(context)) }
    }
