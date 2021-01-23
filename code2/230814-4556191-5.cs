    public void RunTest()
    {
        // This method is creating a new list by doing the following:
        // var r = new List<baseList[0].GetType>(
        //             baseList.Cast<baseList[0].GetType()>);
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
