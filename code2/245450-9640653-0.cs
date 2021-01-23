    public override CLLocationCoordinate2D Coordinate 
    { 
    	get 
    	{ 
    		return this.coordinate; 
    	}
    	set
    	{
    		this.SetCoordinate(value);
    	}
    }
    [Export("_original_setCoordinate:")]
    public void SetCoordinate(CLLocationCoordinate2D coord)
    {
    	this.WillChangeValue("coordinate");
    	this.coordinate = coord;
    	this.DidChangeValue("coordinate");
    }
