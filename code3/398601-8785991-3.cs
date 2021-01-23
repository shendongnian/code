    public static void Main()
    {
        int i = 100;
        CultureInfo it = new CultureInfo("it-IT");
        Console.WriteLine(i.ToString("c", it));
        Console.Read();
    }
