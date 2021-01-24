    private static Random randomGenerator = new Random();
    
    static void Main()
    {
        var hashtags = new List<string>() { "c#", "javascript", "ef", "asp.net" };
    
        var result = GetRandomItems<string>(hashtags, 2);
    
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
    
    private static IEnumerable<T> GetRandomItems<T>(IEnumerable<T> collection, int elementCount)
    {
        var collectionCount = collection.Count();
    
        if (elementCount > collectionCount)
        {
            elementCount = collectionCount;
        }
    
        var collectionCopy = collection.ToList();
    
        var randomIndex = randomGenerator.Next(0, collectionCopy.Count);
    
        for (var index = 0; index < elementCount; index++)
        {
            var tempElement = collectionCopy[index];
    
            collectionCopy[index] = collectionCopy[randomIndex];
            collectionCopy[randomIndex] = tempElement;
    
            randomIndex = randomGenerator.Next(index + 1, collectionCopy.Count);
        }
    
        return collectionCopy.Take(elementCount);
    }
