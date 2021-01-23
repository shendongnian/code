    Console.WriteLine(((List<int>)orderedDictionary["1"]).Count);
    Console.WriteLine(((List<int>)newDictionary["1"]).Count);
    Console.WriteLine(ReferenceEquals(orderedDictionary["1"], newDictionary["1"]));
    ((List<int>)orderedDictionary["1"]).Remove(1);
    Console.WriteLine(((List<int>)orderedDictionary["1"]).Count);
    Console.WriteLine(((List<int>)newDictionary["1"]).Count);
