    public abstract class Child<P, C>
    	where P : Parent<P, C>
    	where C : Child<P, C>
    {
    	public P Parent { get; set; }
    }
    
    public abstract class Parent<P, C>
    	where P : Parent<P, C>
    	where C : Child<P, C>
    {
    	public List<C> Children = new List<C>();
    }
