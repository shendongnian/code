    string input = "1w 2d 1h";
    string[] parts = Regex.Split(input, @"\s+");
    bool success = true;
    if (parts.Length > 3)
    {
        success = false;
    }
    else
    {
        Regex regex = new Regex(@"\d+(?:w|d|h)");
        foreach (string part in parts)
        {
            Match match = regex.Match(part);
            if (!match.Success)
            {
                success = false;
            }
        }
    }
    if (success)
    {
        Console.WriteLine("MATCH");
    }
    else
    {
        Console.WriteLine("NO MATCH");
    }
