    Console.Write("Enter the secret word: ");
    string word = Console.ReadLine();
    
    aCounter = word.Count(letter => letter == 'a');
    bCounter = word.Count(letter => letter == 'b');
    
    if (aCounter > 0)
       Console.WriteLine($"The word contains a : {aCounter}");
    
    if (bCounter > 0)
       Console.WriteLine($"The word contains b : {bCounter}");
