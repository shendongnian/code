    string s = "there is a cat";
    //
    // Split string on spaces.
    // ... This will separate all the words.
    //
    string[] words = s.Split(' ');
    foreach (string word in words)
    {
        Console.WriteLine(word);
    }
