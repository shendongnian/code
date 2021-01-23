    internal sealed class SomeClass : ISomeClass
    {
    	internal SomeClass()
    	{
    		// Add the service to the locator
    		ServiceLocator.Instance.AddService<ISomeClass>(this);
    	}
    	
    	// Maybe remove of service within finalizer or dispose method if needed.
    	
    	internal void SomeMethod()
    	{
    		Console.WriteLine("The user of my library doesn't know I'm doing this, let's keep it a secret");
    	}
    }
    
    public sealed class SomeOtherClass
    {
    	private ISomeClass someClass;
    	
    	public SomeOtherClass()
    	{
    		// Get the service and call a method
    		someClass = ServiceLocator.Instance.GetService<ISomeClass>();
    		someClass.SomeMethod();
    	}
    }
