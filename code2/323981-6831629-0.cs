    void Main()
    {
    	DerivedClass Instance = new DerivedClass();
    	
    	Instance.MethodCaller();
    }
    
    
    class InternalBaseClass
    {
        public InternalBaseClass()
    	{
    	
    	}
    	
    	public virtual void Method()
    	{
    		Console.WriteLine("BASE METHOD");
    	}
    }
    
    class BaseClass : InternalBaseClass
    {
        public BaseClass()
    	{
    	
    	}
    	
    	public void MethodCaller()
    	{
    		base.Method();
    	}
    }
    
    class DerivedClass : BaseClass
    {
    	public DerivedClass()
    	{
    	
    	}
    	
    	public override void Method()
    	{
    		Console.WriteLine("DERIVED METHOD");
    	}
    }
