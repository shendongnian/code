    public void RunTest()
    {
        var elementType = baseList[0].GetType();
    	
        // Get the System.Linq.Enumerable Cast<elementType> method.
        var castMethod = typeof(Enumerable)
                       .GetMethod("Cast", BindingFlags.Public | BindingFlags.Static)
                       .MakeGenericMethod(elementType);
    		
        Object o = Activator.CreateInstance(typeof(CallMe), 
                   new [] { castMethod.Invoke(null, new[] {baseList}) });
    }
