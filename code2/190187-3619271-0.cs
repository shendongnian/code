    public class A
    {
    	/// <summary>
    	/// Unique instance to access to object A
    	/// </summary>
    	public static readonly A Singleton = new A();
    
    	/// <summary>
    	/// private constructor so it can only be created internally.
    	/// </summary>
    	private A()
    	{
    	}
    
    	/// <summary>
    	/// Instance method B does B..
    	/// </summary>
    	public void B()
    	{
    	}
    }
