    foreach (string line in lines)
    {
        Console.WriteLine(line);
        lines.Add("Attempting a new line"); // throws an exception.
        lines.Remove("Attempting a new line"); // throws an exception.
    }
