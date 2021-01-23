    public event PropertyChangedEventHandler PropertyChanged;
    
    private void NotifyPropertyChanged(string info)
    {
    	if (PropertyChanged != null)
    	{
    		PropertyChanged(this, new PropertyChangedEventArgs(info));
    	}
    }
	
    public string Title
    {
    	get
    	{
    		return this._title;
    	}
    	
    	set
    	{
    		if (this._title != value)
    		{
    			this._title = value;
    			NotifyPropertyChanged("Title");
    		}
    	}
    }
