    Dictionary<string, string> dic = new Dictionary<string, string>
    {
        { "BUL", "100" },
        { "GVL", "200" },
        { "UDF", "300" },
        { "RFT", "400" },
        { "WDR", "500" }
    };
    
    while(true)
    {
        Console.WriteLine("Enter Username");
        string inputUsername = Console.ReadLine();
        Console.WriteLine("Enter Password");
        string pass = Console.ReadLine();
    
        if (!dic.Contains(new KeyValuePair<string, string>(inputUsername, pass)))
            Console.WriteLine("Incorrect Username/password, Try again");
        else  break;
    }
