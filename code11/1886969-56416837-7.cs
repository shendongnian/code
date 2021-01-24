    var array = new int[10];
    
    var lowerBound = array.GetLowerBound(0);
    var upperBound = array.GetUpperBound(0);
    
    for (int i = lowerBound; i <= upperBound; i++)
    {
        Console.WriteLine($"{i + 1}: {array[i]}"); // Print "[line number]: [element]".
        // Console.WriteLine(array[i]); // Print element only.
    }
