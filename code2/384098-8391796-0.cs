    private static void outputDictionaryContentsByDescending(Dictionary<string, int> list)
    {
        int iHowMany = 20;
        foreach (KeyValuePair<string, int> pair in list.OrderByDescending(key => key.Value))
        {
            if(iHowMany-- > 0)
                Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
        }
    }
