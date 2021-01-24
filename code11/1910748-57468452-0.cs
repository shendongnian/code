    Console.WriteLine(origDict.Count); // outputs 1
    
    var tempDict = new Dictionary<string, Dictionary<int, List<dynamic>>>(origDict);
    
    Console.WriteLine(tempDict.Count); // outputs 1
    
    origDict.Clear();
    
    Console.WriteLine(origDict.Count); // outputs 0
    Console.WriteLine(tempDict.Count); // outputs 1
