    public abstract class MyClass
    {
    	public string Name { get; set; }
    }
    
    // Only classes in this assembly can derive from this class
    internal abstract class InternalClass : MyClass
    {
    	protected string Other { get; set; }
    }
