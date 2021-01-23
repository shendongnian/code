	double d = Double.NaN;
	int i;
	if(Int32.TryParse(d.ToString(), out i))
	{
		Console.WriteLine("Success");
		Console.WriteLine(i);
	} else {
		Console.WriteLine("Fail");
	}	
