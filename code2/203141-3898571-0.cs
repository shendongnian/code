    public enum Operators
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        Power
    }
    string[] available_ops = Enum.GetNames(typeof(Operators));
    foreach(string op in available_ops) //IEnumerable<string> working here
        Console.WriteLine("Available operator: {0}", op);
