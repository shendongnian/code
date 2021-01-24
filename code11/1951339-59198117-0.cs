        Console.Write("Input the number of elements to be stored in the array :");
        n = Convert.ToInt32(Console.ReadLine());
		List<int> a = new List<int>();
       			
		for (i = 0; i < n; i++)
	    {
	            Console.Write("element - {0} : ", i);
	            a.Add(Convert.ToInt32(Console.ReadLine()));
	    }
		var dict = a.GroupBy(x=>x).ToDictionary(x=>x.Key,y=>y.Count());
		Console.WriteLine("Duplicates");
		foreach(var pair in dict)
		{
			Console.WriteLine($"{pair.Key} occured {pair.Value} times");
		}
		Console.WriteLine("Distinct");
		foreach(var pair in dict)
		{
			Console.WriteLine($"{pair.Key}");
		}
