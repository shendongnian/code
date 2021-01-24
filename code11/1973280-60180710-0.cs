    private int _a;
	public int A
    {
        get
        {
            return _a;
        }
        set
        {
			bool success = Int32.TryParse(value.ToString(), out int number);
         	if (success)
         	{
            	_a = number;
         	}
            
        }
    }
