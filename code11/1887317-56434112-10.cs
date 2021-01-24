    /// <summary>
    /// Method to calculate a circle
    /// </summary>
    /// <param name="x"></param>      
    /// <returns></returns>
    static double Pole(int x)
    {
         return 3.14(x * x);
    }
    static void Main(string[] args)
    {
        int x = 2;
        Console.WriteLine(Pole(x));
        Console.ReadKey();
    }
