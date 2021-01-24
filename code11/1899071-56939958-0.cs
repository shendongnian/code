    string pattern = @"^.+\.(0?[0-8])$";
    string[] inputs = new [] { "I-000146.22.43.24", "I-000146.22.43.09", 
                               "I-000146.22.43.08", "xxxxxxx.07" };
    foreach (string input in inputs)
    {
        Match match = Regex.Match(input, pattern);
        if (match.Success)
            Console.WriteLine($"The input is valid. Last number is '{match.Groups[1].Value}'.");
        else
            Console.WriteLine("The input is not valid.");
    }
