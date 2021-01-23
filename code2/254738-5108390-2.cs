    class baseTest 
    {
    	private string _t = string.Empty;
    	public virtual string t {
    		get{return _t;}
    		set
    		{
    			Console.WriteLine("I'm in base");
    			_t=value;
    		}
    	}
    }
    
    class derived : baseTest
    {
    	public override string t {
    		get { return base.t; }
    		set 
    		{
    			Console.WriteLine("I'm in derived");
    			base.t = value; 
    		}
    	}
    }
    
    class Program
    {
    		
    	public static void Main(string[] args)
    	{
    		var tst2 = new derived();
    		tst2.t ="d"; 
    		// OUTPUT:
    		// I'm in derived
    		// I'm in base
    	}
    }
