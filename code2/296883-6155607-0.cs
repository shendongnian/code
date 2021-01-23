    private CvarAspectRatios _aspectRatio; //No field initialization because that would not attach event handler, you could do it though and take care of the handler alone in the ctor
    public CvarAspectRatios AspectRatio
    {
    	get { return _aspectRatio; }
    	set
    	{
    		if (_aspectRatio != value) // WTH @ "value != null"
    		{
    			_aspectRatio.PropertyChanged -= AspectRatio_PropertyChanged;
    			_aspectRatio = value;
    			_aspectRatio.PropertyChanged += new PropertyChangedEventHandler(AspectRatio_PropertyChanged);
    			NotifyPropertyChanged("AspectRatio");
    		}
    	}
    }
    
    void AspectRatio_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    	if (e.PropertyName == "Value")
    	{
    		NotifyPropertyChanged("ResolutionList");
    	}
    }
