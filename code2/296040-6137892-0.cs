    static void Main()
    {
        string myString = "USD3,000";
        var match = Regex.Match(myString, @"[0-9].*");
        if(match.Success)
        {
            Console.WriteLine(match.Value);
        }
    }
