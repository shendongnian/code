	// Add all of the numbers 0 to 100 to a list
    var availableNumbers = new List<int>();
	for (int i = 0; i < 100; ++i)
	{
		availableNumbers.Add(i);
	}
	
	Random random = new Random();
	for (int i = 0; i < 40; ++i)
	{
		// Choose a random position in the available numbers list
		var idx = random.Next(0, availableNumbers.Count);
		
		// Print the number from this position in the list
		Console.WriteLine(availableNumbers[idx]);
		
		// Remove the item at this position
		availableNumbers.RemoveAt(idx);
	}
	
