    public class FirstName
    {
    	private string _Value;
    	public string Value
    	{
    		get
    		{
    			return _Value;
    		}
    		set
    		{
    			if (string.IsNullOrEmpty(value))
    				throw new ArgumentNullException("Value cannot be null");
    			if (value.Length > 128)
    				throw new ArgumentOutOfRangeException("Value cannot be longer than 128 characters");
    			_Value 	= value;
    		}
    	}
    	
    	public FirstName(string initialValue)
    	{
    		Value 	= initialValue; //does validation check even in constructor
    	}
    }
