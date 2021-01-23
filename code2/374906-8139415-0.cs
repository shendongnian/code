    public abstract class ABase<T>
    {
    	public abstract T MyMethod();
    }
    
    public class A : ABase<A>
    {
    	public override A MyMethod()
    	{
    		throw new NotImplementedException();
    	}
    }
    
    public class B : A
    {
    }
