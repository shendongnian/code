    string _phoneNumber;
    
    public string PhoneNumber
    {
    	get
    	{
    		return _phoneNumber;
    	}
    	set
    	{
    		if (value.Length <= 30)
    		{
    			_phoneNumber = value;
    		}
    		else 
    		{
    			_phoneNumber = "EXCEEDS LENGTH";
    		}
    	}
    }
