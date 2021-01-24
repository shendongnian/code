    void Main()
    {
	   List<string> strings = new List<string> () {"A", "B", "C", "D", "E"};
	
	   foreach (var item in OutputCombinations(strings))
	   {
		  Console.WriteLine($"[{item.Item1}{item.Item2}]");
	   }
    }
