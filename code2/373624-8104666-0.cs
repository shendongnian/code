    static void Main(string[] args)
    {
        try
        {
            //Code which throws exceptions from time to time and runs in a loop
            Console.WriteLine("Line 1");
            throw new Exception("Sample Exception"); // your code will stop here and following line will not prine.
            Console.WriteLine("This line will not print");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        Console.ReadKey();
    }
