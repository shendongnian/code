    string word = ("internet");
    
    for (int i = 0; i < word.Length ; i++) 
    {
        for (int j = 0; j < i ; j++) 
        {
            Console.Write(" ");
        }
        Console.WriteLine(word);
    }
