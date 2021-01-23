    string words = "i love love vb development although i m a total newbie";
    string[] keywords = new[] { "love", "development", "fire", "stone" };
    
    Regex regex = new Regex("\\w+");
    
    var frequencyList = regex.Matches(words)
        .Cast<Match>()
        .Select(c => c.Value.ToLowerInvariant())
        .Where(c => keywords.Contains(c))
        .GroupBy(c => c)
        .Select(g => new { Word = g.Key, Count = g.Count() })
        .OrderByDescending(g => g.Count)
        .ThenBy(g => g.Word);
    
    //Convert to a dictionary
    Dictionary<string, int> dict = frequencyList.ToDictionary(d => d.Word, d => d.Count);
    
    //Or iterate through them as is
    foreach (var item in frequencyList)
        Response.Write(String.Format("{0}, {1}", item.Word, item.Count));
