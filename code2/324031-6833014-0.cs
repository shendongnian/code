    void Main()
    {
    	var NewProduct = ExistingProduct.With(P => P.Name = "Test2");
    }
    
    // Define other methods and classes here
    
    public static class Extensions
    {
    	public T With<T>(this T Instance, Action<T> Act) where T : ICloneable
    	{
    		var Result = Instance.Clone();
    		Act(Result);
    		
    		return Result;
    	}
    }
