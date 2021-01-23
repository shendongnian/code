    static IEnumerable<string> Dedupe(this IEnumerable<string> input, char seperator, int keyIndex)
    {
        var hashset = new HashSet<string>();
        foreach (string item in input)
        {
            var array = item.Split(seperator);
            if (hashset.Add(array[keyIndex]))
                yield return item;
        }
    }
... 
    var list = new string[] 
    {
        "apple|pear|fruit|basket", 
        "orange|mango|fruit|turtle",
        "purple|red|black|green",
        "hero|thor|ironman|hulk"
    };
    foreach (string item in list.Dedupe('|', 2))
        Console.WriteLine(item);
