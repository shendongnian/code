    class Program
    {
    	static void Main(string[] args)
    	{
    		var obj = new Child().SetId("id").SetName("aaa");
    	}
    }
    
    public class Parent<T>
    {
    	public virtual T SetId(string id)
    	{
    		// this does not work
    		return (T)this;
    
    		// this compiles but is NOT what we want :(
    		//return default(T);
    	}
    }
    
    public class Child : Parent<Child>
    {
    	public Child SetName(string name)
    	{
    		return this;
    	}
    }
