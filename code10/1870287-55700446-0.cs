    private IDataRepository _dataRepository = null;    
    public IDataRepository DataRepository 
    {
        get { return _dataRepository ?? (_dataRepository = ContainerRegistry.Instance.Resolve<IDataRepository>());}
        set { _dataRepository = value; }
    }
