    String[] values = { "87878787878", "676767676767", "8786676767", "77878785565", "987867565659899698" };
    
    if (Array.TrueForAll(values, value =>
    {
    	Int64 s;
    	return Int64.TryParse(value, out s);
    }
    ))
    
    Console.WriteLine("All elements are  integer.");
    else
    Console.WriteLine("Not all elements are integer.");
