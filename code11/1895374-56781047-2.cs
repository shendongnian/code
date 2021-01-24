    Dictionary<string, int> myDict; //Not initialized        
    //You would get the warning for myDict here instead
    if (myDict.TryGetValue("hello", out var value) == true)
    {
        Console.WriteLine("Hello" + value.ToString());
    }
