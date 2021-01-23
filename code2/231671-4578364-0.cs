    List<string> list = new List<string>(new string[] { "cat", "Dog", "parrot", "dog", "parrot", "goat", "parrot", "horse", "goat" });
    Dictionary<string, int> wordCount = new Dictionary<string, int>();
     
    //count them all:
    list.ForEach(word =>
    {
        string key = word.ToLower();
        if (!wordCount.ContainsKey(key))
            wordCount.Add(key, 0);
        wordCount[key]++;
    });
    
    //remove words appearing only once:
    wordCount.Keys.ToList().FindAll(word => wordCount[word] == 1).ForEach(key => wordCount.Remove(key));
    
    Console.WriteLine(string.Format("Found {0} duplicates in the list:", wordCount.Count));
    wordCount.Keys.ToList().ForEach(key => Console.WriteLine(string.Format("{0} appears {1} times", key, wordCount[key])));
