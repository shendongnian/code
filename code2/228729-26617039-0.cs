    public struct MyStruct
    {
    	private bool _name;
    	public string myName
    	{
    		get { return (_name ? myName : "Default name"); }
    		set { _name = true; myName = value; }
    	}
    	private bool _num;
    	public int myNumber 
    	{
    		get { return (_num ? myNumber : 42); }
    		set { _num = true; myNumber = value; }
    	}
    	private bool _bool;
    	public bool myBoolean
    	{
    		get { return (_bool ? myBoolean : true); }
    		set { _bool = true; myBoolean = value; }
    	}
    	private bool _type;
    	public MyRefType myType
    	{
    		get { return _type ? myType : new MyRefType(); }
    		set { _type = true; myType = value; }
    	}
    }
