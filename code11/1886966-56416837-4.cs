    var array = new int[10]; // Tally in your case
    
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine($"{i + 1}: {array[i]}"); // Print "[line number]: [element]".
        // Console.WriteLine(array[i]); // Print element only.
    }
