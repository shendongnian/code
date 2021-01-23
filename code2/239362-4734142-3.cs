    Regex re = new Regex(@"\d+");
    Match m = re.Match("test 66");
    
    if (m.Success)
    {
        Console.WriteLine(string.Format("RegEx found " + m.Value + " at position " + m.Index.ToString()));
    }
    else
    {
        Console.WriteLine("You didn't enter a string containing a number!");
    }
