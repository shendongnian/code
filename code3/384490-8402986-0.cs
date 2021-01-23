    private static void outputNumOfTotalTags(Dictionary<string, int> list)
    {
        int numOfTags = 0;
        foreach (KeyValuePair<string, int> pair in list)
        {
            numOfTags += pair.Value;
        }
        Console.WriteLine("The total number of hashtags is: {0}\n", numOfTags);
    }
