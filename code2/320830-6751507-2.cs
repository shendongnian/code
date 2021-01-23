    int value;
    if( dictionary.TryGetValue("L5", out value) )
    {
        //Key exists already
        Console.WriteLine("L5 has a value of {0}", value);
    }
    else
    {
        //Key does not exist
        dictionary.Add("L5", 1);
    }
