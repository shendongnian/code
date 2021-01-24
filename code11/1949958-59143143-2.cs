    void Main()
    {
    	var container = new UnityContainer()
    		.RegisterInstance<string>("I'm the other parameter");
    
    	var foo1 = container.Resolve<RedFooUser>();
    	var foo2 = container.Resolve<BlackFooUser>();
    
    }
    
    // Define other methods, classes and n
    public interface IFoo 
    {
    }
    public class BlackFoo : IFoo { }
    public class RedFoo : IFoo { }
    
    public abstract class FooUser<TFoo> where TFoo : IFoo
    {
    
    	private readonly TFoo _foo;
    	public FooUser(TFoo foo, string otherParameter)
    	{
    		_foo = foo;
    		Console.WriteLine($"Constructed {GetType().Name} with foo '{foo.GetType().Name}' and otherParameter '{otherParameter}'");
    	}
    }
    
    public class BlackFooUser : FooUser<BlackFoo>
    {
    	public BlackFooUser(BlackFoo foo, string otherParameter)
    		: base(foo, otherParameter)
    	{
    	}
    }
    
    public class RedFooUser : FooUser<RedFoo>
    {
    	public RedFooUser(RedFoo foo, string otherParameter)
    		: base(foo, otherParameter)
    	{
    	}
    }
