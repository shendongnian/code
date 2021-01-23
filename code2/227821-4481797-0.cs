    public object Document
    {
    	get { return document; }
    	set
    	{
    		document = value;
    		this.PropertyChanged(this, new PropertyChangedEventArgs("Document"));
    	}
    }
