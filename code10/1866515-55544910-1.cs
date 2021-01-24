	public static object TryDoStuff()
	{
		var result =0;
		for (int i = 0; i < 3; i++)
		{
				Console.WriteLine("Add 100 unit");
				result += 100;
				// return result; you can un-comment this line too
		}	
	
		Console.WriteLine("last line");
        return result;
	}
