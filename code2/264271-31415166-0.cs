    string EmailPattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
    if (Regex.IsMatch(Email, EmailPattern, RegexOptions.IgnoreCase))
    {
        Console.WriteLine("Email: {0} is valid.", Email);
    }
    else
    {
        Console.WriteLine("Email: {0} is not valid.", Email);
    }
