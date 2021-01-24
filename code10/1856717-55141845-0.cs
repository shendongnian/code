    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        if (double.TryParse(input, out double d))
        {
            Console.WriteLine(d);
        }
        else
        {
            Console.WriteLine("Input is not a double.");
        }
    }
