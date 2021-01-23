    class baseTest 
    {
    	private string _t = string.Empty;
    	public virtual string t {
    		get{return _t;}
    		set{_t=value;}
    	}
    }
    
    class derived : baseTest
    {
    	public override string t {
    		get { return base.t; }
    		set { base.t = value + " from derived"; }
    	}
    }
