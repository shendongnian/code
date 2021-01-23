    for (int subListIndex = 0; subListIndex < response.Count; subListIndex++)
    {
        for (int itemIndex = 0; itemIndex < response[subListIndex].Length; itemIndex++)
        {
            Console.WriteLine(response[subListIndex][itemIndex]);
        }
    }
