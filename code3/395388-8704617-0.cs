    public abstract class GenericBase<T>
    	where T : IEquatable<T>
    {
    	public T SomeProperty { get; set; }
    }
    
    public class Foo<T>
    {
    	public T SomeProperty { get; set; }
    }
    
    public abstract class GenericChild<T> : GenericBase<T>
    	where T : IEquatable<T>
    {
    	// ... 
    
    	public bool DoSomething(Foo<T> foo)
    	{
    		// This is valid: 
    		return SomeProperty.Equals(foo.SomeProperty);
    	}
    }
