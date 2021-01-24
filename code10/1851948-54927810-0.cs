public GenerarRetiroCentroViewModel GetInstance()
{
	if(instance == null){
	    instance = new GenerarRetiroCentroViewModel();
	}
	
	return instance;
}
Actually, you don't even need a function.
public GenerarRetiroCentroViewModel Instance
{
	get
	{
		if(instance == null){
		    instance = new GenerarRetiroCentroViewModel();
		}
		
		return instance;
	}
}
___
Note: That is not thread-safe. 
If you want to make it thread-safe, you can use [Lazy](https://docs.microsoft.com/de-de/dotnet/api/system.lazy-1?view=netframework-4.7.2) (.NET 4+).
public sealed class SingletonClass
{
	private static readonly Lazy<SingletonClass> _lazy =  new Lazy<SingletonClass>(() => new SingletonClass());
	
	public static SingletonClass Instance 
	{
		get
		{
			return _lazy.Value;
		}
	}
			
}
It basically creates a Singleton the first time someone tries to access that property.
