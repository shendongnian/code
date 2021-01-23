    // add @ to the string to allow split over multiple lines 
    // (display purposes to save scroll bar appearing on SO question :))
    string strBig = @"Retrieves a substring from this instance. 
                The substring starts at a specified character position. great";
    
    // split the string on the fullstop, if it has a length>0
    // then, trim that string to remove any undesired spaces
    IEnumerable<string> subwords = strBig.Split('.')
        .Where(x => x.Length > 0).Select(x => x.Trim());
    
    // iterate around the new 'collection' to sanity check it
    foreach (var subword in subwords)
    {
        Console.WriteLine(subword);
    }
