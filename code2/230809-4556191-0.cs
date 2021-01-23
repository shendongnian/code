    public void RunTest()
    {
        // Create a List<T> where T is the type of the first element of baseList.
        var listType = typeof(List<>).MakeGenericType(new[] {baseList[0].GetType()});
        var r = Activator.CreateInstance(listType);
    	
        // There isn't an interface we can use because this is a generic list.
        // Get a reference to the Add method. Add add each of the items 
        // from baseList.
        var addMethod = listType.GetMethod("Add", 
                                           BindingFlags.Public 
                                           | BindingFlags.Instance);
    	
        foreach (var x in baseList)
        {
            addMethod.Invoke(r, new [] { x });
        }
    
        Object o = Activator.CreateInstance(typeof(CallMe), 
                                            new object[] { r });
    }
