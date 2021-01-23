    Dictionary<int, List<string>> castMeDict = 
        new Dictionary<int, List<string>>();
    Dictionary<int, IEnumerable<string>> getFromDict = 
        (Dictionary<int, IEnumerable<string>>)castMeDict;
    castMeDict[123] = new List<string>();
    IEnumerable<string> strings = getFromDict[123]; // No problem!
    getFromDict[123] = new string[] { "hello" }; // Big problem!
