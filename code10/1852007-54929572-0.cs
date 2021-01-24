    public class ParentClass
    {
    	public void TopMethod()
    	{
    		Console.WriteLine("Top method in parent");
    		Method1();
    	}
    
    	public virtual void Method1()
    	{
    		Console.WriteLine("Method1 in parent");
    	}
    }
    public class ChildClass : ParentClass
    {
    	public override void Method1()
    	{
    		Console.WriteLine("Method1 in child");
    	}
    }
