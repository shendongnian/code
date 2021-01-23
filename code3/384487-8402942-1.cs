    private static void outputNumOfTotalTags(Dictionary<string, int> list)
    {
        // if you don't need a seed value, and just want the sum of list's values:
        var numOfTags = list.Sum(pair => pair.Value);
        Console.WriteLine("The total number of hashtags is: {0}\n", numOfTags);
    }
