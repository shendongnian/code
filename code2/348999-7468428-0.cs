    // Retrieve all classes that are typeof SomeClassOrInterface
    
    List<Type> myTypes = assembly.GetTypes().Where(typeof(SomeClassOrInterface).IsAssignableFrom).ToList();
    
    // Loop thru them or just use Active.CreateInstance() of the type you need
    
    myTypes.ForEach(myType => {
    	SomeClassOrInterface instance = Activator.CreateInstance(myType) as SomeClassOrInterface;                         	
    });
