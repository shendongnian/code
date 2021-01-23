    public class MyClass : IMyClass
    {
    	public bool Equals(IMyClass other)
    	{		
    	}
    }
    
    public interface IMyClass : IEquatable<IMyClass>
    {
    	
    }
