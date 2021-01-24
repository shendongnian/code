        var instances = new Base[]
		{
			new A(),
			new B()
		};
		
		foreach(var instance in instances)
		{
			if(instance.IsMatch(name))
			{
				return instance;
			}
		}
    public abstract class Base
    {
    	public abstract bool IsMatch(string name);
    }
    
    public class A : Base
    {
    	public override bool IsMatch(string name)
    	{
    		return name.ToUpper() == "A";
    	}
    }
    
    public class B : Base
    {
    	public override bool IsMatch(string name)
    	{
    		return name.ToUpper() == "B";
    	}
    }
