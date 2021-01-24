	int[] a1 = new int[10];
	var rnd = new Random();
	//takes an input
	for (int i = 0; i < a1.Length; i++)
	{
		a1[i] = Convert.ToInt32(rnd.Next(0, 11)); // or Console.ReadLine()
	}
	var grouped = a1
	  .GroupBy(x => x)
	  .Select(g => new
	  {
		  g.Key,
		  Item = g.FirstOrDefault(),
		  Count = g.Count()
	  }).ToList(); // ToList() is optional, materializes the IEnumerable
  
	foreach (var item in grouped)
	{
		Console.WriteLine($"number: {item.Item}, count: {item.Count}");
	}
