    string[] inputs = { "82&?", "82,9", "abse82,9>dpkg", "foobar" };
    foreach (var input in inputs)
    {
        Match m = Regex.Match(input, @"\d+(,\d+)?");
        if (m.Success)
        {
            Console.WriteLine(m.Value);
        }
        else
        {
            Console.WriteLine("No match!");
        }
    }
