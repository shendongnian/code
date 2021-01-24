    var myList = new List<int>() { 1, 2, 3, 4, 5, 6 };
    
    var myEnumerable = myList.Where(p =>
    {
    	Console.Write($"{p} ");
    	return p > 2;
    }).ToTrackingEnumerable();
    
    Console.WriteLine("Starting");
    var first = myEnumerable.First();
    Console.WriteLine("");
    var second = myEnumerable.Where(p => p % 2 == 1).First();
    Console.WriteLine("");
