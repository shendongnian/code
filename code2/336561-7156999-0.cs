    public IEnumerable<TotalViewModel> FirstOne 
    { 
    	get
    	{
    		return _firstOne;
    	}
    	private set
    	{
    		_firstOne = value;
    		RaisePropertyChanged("FirstOne");
    	}
    }
