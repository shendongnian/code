    public void Linq96() 
    { 
        var wordsA = new string[] { "cherry", "apple", "blueberry" }; 
        var wordsB = new string[] { "cherry", "apple", "blueberry" }; 
      
        bool match = wordsA.SequenceEqual(wordsB); 
      
        Console.WriteLine("The sequences match: {0}", match); 
    } 
