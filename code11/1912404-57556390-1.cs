    static void Main(string[] args)
    {
        string inputFileName;
        if (args.Count() == 0)
        {
            inputFileName = Console.ReadLine();
        }
        else if (args.Count() == 1)
        {
            inputFileName = args[0];
        }
        else
        {
            ... Grumble about unexpected arguments;
        }
