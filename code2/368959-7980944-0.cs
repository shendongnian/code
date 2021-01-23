    Match match = Regex.Match(input, @"^.*([0-9]{5}[1-9])0{1,}$", RegexOptions.IgnoreCase);
    
    // Here we check the Match instance.
    if (match.Success)
    {
    	// Finally, we get the Group value and display it.
    	string key = match.Groups[1].Value;
    	Console.WriteLine(key);
    }
