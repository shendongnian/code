	try {
		ExceptionThrower.ThisRethrows();
	} 
	catch(Exception ex) {
        // using LINQ to print all the nested Exception Messages
        // separated by commas
		var s = ex.GetAllExceptions()
		.Select(e => e.Message)
		.Aggregate((m1, m2) => m1 + ", " + m2);
	
		Console.WriteLine(s);
	}
