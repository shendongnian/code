    class X {
    	static public void X1 ()
    	{
    		Console.WriteLine ("Static");
    	}
    	public void X1 (bool x1 = false)
    	{
    		X1(); // Which one is this calling?
    		Console.WriteLine ("Instance");
    	}
    }
    void Main()
    {
    	X.X1 (); // Static
    	new X ().X1 (false); // Instance
    }
