    public bool getInput(string message, out string result)
    {
        Console.WriteLine(message);
        result = Console.ReadLine();
        return (!result.Equals("0"))
    }
