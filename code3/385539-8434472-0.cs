	// get the method
	var openMethod = typeof(Program).GetMethod(
		"AssertDictionary", BindingFlags.NonPublic | BindingFlags.Static);
	
	// get type arguments of the dictionary
	var dictTypeArgs = o1.GetType().GetGenericArguments();
	
	// set the type parameters of the method
	var closedMethod = openMethod.MakeGenericMethod(dictTypeArgs);
	
	// invoke the method
	closedMethod.Invoke(null, new [] { o1, o2 });
