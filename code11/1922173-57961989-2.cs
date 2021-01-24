    int occurances = 0;
    string[] words = new string[_wordCount];
    var results = new Dictionary<string, int>();
    var splitSentence = _sentence.Split(' ').ToArray();
    for(int i = 0; i < words.Length; i++)
    {
        Console.WriteLine("Type in the censored words you wish to be counted: ");
        words[i] = Console.ReadLine();
        
        if(_sentence.Contains(words[i]))
        {
            if(!results.ContainsKey(words[i]))
            {
                results.Add(words[i], 0);
            }
            
            for(var j = 0; j < splitSentence.Length; j++)
            {
                if(splitSentence[j] == words[i])
                {
                     results[words[i]]++;
                }
            }
            occurances++;
        }
    }
