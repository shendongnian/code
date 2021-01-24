    string[] SpeachSplit = Speach.Split();
    Dictionary<string, int> Historgram = new Dictionary<string, int>();
    // loop through all words
    for (var i = 0; i < SpeachSplit.Length; i++)
    {
        string word = SpeachSplit[i];
        // check if your word is already in the dictionary
        if(!Historgram.ContainsKey(word))
        {
            // if it is not in the dictionary, add it to dictionary with 0 occurrences
            Historgram.Add(word, 0);
        }
        // add one to the number of occurrences
        Historgram[word]++;
    }
    // at this point dictionary contains words as keys and number of occurrences as value
