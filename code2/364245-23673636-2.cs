    class Program
    {
    	static void Main(params string[] args)
    	{
    		typeof(Foo).GetCustomAttribute<Attr1>();
    	}
    
    	[AttributeUsageAttribute(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    	public class Attr1 : Attribute
    	{
    	}
    
    	public class Attr2 : Attr1
    	{
    	}
    
    	[Attr1]
    	[Attr2]
    	public class Foo
    	{
    	}
    
    	[Attr1]
    	public class Bar : Foo
    	{
    	}
    }
