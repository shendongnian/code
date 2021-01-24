    public static void Main(string[] args)
    {
        using(object obj = new ObjectWithTimer())
        {
           Console.ReadLine();
           Console.WriteLine("obj=null");
        }
        Console.ReadLine();
    }
