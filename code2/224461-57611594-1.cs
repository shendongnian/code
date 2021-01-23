    string testString = "Silver badges are awarded for longer term goals. Silver badges are uncommon.";
    int length = 35;
    List<string> test = SplitWordsByLength(testString, length);
    foreach (string chunk in test)
    {
        Console.WriteLine(chunk);  
    }
    Console.ReadLine();
