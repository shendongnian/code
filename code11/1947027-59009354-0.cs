    var valuesToCheck = new List<int> { 20, 40, 50};
	if(valuesToCheck.Any(x => x.Equals(20))) 
	{
	  Console.WriteLine("yes");
	}
    else
	{
	   Console.WriteLine("no");
	}
