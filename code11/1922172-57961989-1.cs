    int occurances = 0;
    string[] words = new string[_wordCount];
    var results = new Dictionary<string, int>();
    
    for(int i = 0; i < words.Length; i++)
    {
        Console.WriteLine("Type in the censored words you wish to be counted: ");
        var input = Console.ReadLine(); // instead of input you can also use `words[i] = Console.ReadLine();` if you wish.
        
        if(_sentence.Contains(input))
        {
            if(!results.ContainsKey(input))
            {
                results.Add(input, 1);
            }
            else
            {
                results[input]++;
            }
            occurances++;
        }
    }
