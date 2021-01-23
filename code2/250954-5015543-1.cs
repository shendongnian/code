    public SelectedIndex{get;set;}
    public Visibility showcb2
    {
    	get
    	{
    		if (SelectedIndex == 0)
    		{
    			return Visibility.Visible;
    		}
    		return Visibility.Collapsed;
    	}			
    }
	
    public Visibility showcb3
    {
    	get
    		{
    		if (SelectedIndex == 0)
    		{
    			return Visibility.Visible;
    		}
    		return Visibility.Collapsed;
    	}			
    }
 
