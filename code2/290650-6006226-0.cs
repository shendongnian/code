    public void Parse(string input)
    {
        string[] parts = input.Split('.');
        int number = int.Parse(parts[0]); // convert the number to int
        string str = parts[1].Trim(); // remove extra whitespace around the remaining string
    }
