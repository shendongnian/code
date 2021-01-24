    public static void Main()
    {
        string mode = null;
        string abc = mode?.ToLower() ?? "cs"; // if null, use "cs"
        if(abc == "cs")
        {
            Console.WriteLine("not null");
        }
        Console.WriteLine(abc);
    }
