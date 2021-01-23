    public void RunTest()
    {
        var elementType = baseList[0].GetType();
    	
        // Get the System.Linq.Enumerable Cast<elementType> method.
        var castMethod = typeof(Enumerable)
                       .GetMethod("Cast", BindingFlags.Public | BindingFlags.Static)
                       .MakeGenericMethod(elementType);
    			
        // Create a List<elementType>, using the Cast method to populate it.
        var listType = typeof(List<>).MakeGenericType(new [] { elementType });
        var r = Activator.CreateInstance(listType, 
                new [] {castMethod.Invoke(null, new [] {baseList})});
    		
        Object o = Activator.CreateInstance(typeof(CallMe), 
                   new [] { r });
    }
