    internal interface IGeneric { }
    interface IGeneric<T> : IGeneric { }
	public void foo<T>() where T : IGeneric
	{
		var tGenericU= typeof(T)
					.GetInterfaces()
					.Where( i=> 
							   i.IsGenericType 
							&& i.GetGenericTypeDefinition() == typeof(IGeneric<>) )
					.FirstOrDefault();
		Debug.Assert(typeofU != null);
		var typeofU= tGenericU.GetGenericArguments().First();			  
		
		// do something
		Console.WriteLine( typeofU );
	}
