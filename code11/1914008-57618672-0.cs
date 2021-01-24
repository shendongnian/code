    class MyType 
    {
    	public override bool Equals(object obj)
    	{
    		return base.Equals(obj);
    	}
    	public override int GetHashCode()
    	{
    		return base.GetHashCode();
    	}
    	public static bool operator == (MyType x, double c)
    	{
           // write some real code here - this one does not have a value to compare to. 
           return c > 42; 
    	}
    
        // you need all several overrides for each operator to behave in expected way
        // so calling the same one (a == b)
        // from a != b, b != a, b == a is a way to keep them consistent
    	public static bool operator == (double c, MyType x)
    	{
    		return (x == c);
        }
    
    	public static bool operator != (double c, MyType x)
    	{
    		return !(c == x);	
    	}
    	
    	public static bool operator != (MyType x, double c)
    	{
    		return !(x == c);
    	}
    }
