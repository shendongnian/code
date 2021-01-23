    string data = "ATTRIBUTE ISC_FLOW ...
    string[] delimiters = new string[]
    {
        "FLOW_VERIFY",
        "FLOW_ENABLE",
        "FLOW_ERASE",
        "FLOW_PRELOAD",
        "FLOW_PROGRAM"
    };
    List<string> results = Split(data, delimiters);
    for (int i = 0; i < results.Count; i++)
    {
        Console.WriteLine("{0}. {1}", i + 1, results[i]);
        Console.WriteLine();
    }
    Console.Read();
