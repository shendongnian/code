    public static void Main()
    {
       Console.Write("Hello ");
       // current output
       var current = Console.Out;
    
       // change the output to somewhere else
       Console.SetOut(new StreamWriter(Stream.Null));
       Run();
       // revert back
       Console.SetOut(current);
       Console.WriteLine("there");
    }
    
    private static void Run()
    {
       Console.Write("Doctor, please keep touching me ");
    }
