    public static unsafe void Main(string[] args)
    {
        int a, b,c;
        string str = "10 12 100";
        sscanf(str, ' ', &a, &b, &c);
        Console.WriteLine("{0} {1} {2}", a, b, c);
        Console.Read();
    }
    public static unsafe void sscanf(string str, char seperator, params int*[] targets)
    {
        var parts = str.Split(seperator);
        if (parts.Length != targets.Length) throw new ArgumentException();
        for (int i = 0; i < parts.Length; i++)
        {
            *targets[i] = int.Parse(parts[i]);
        }
    }
