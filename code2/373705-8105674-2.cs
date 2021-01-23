    static double f(double a, double b)
    {
        return a - b * Math.Round(a / b);
    }
    static void Main(string[] args)
    {
        Console.WriteLine(1.9 % 1.0);
        Console.WriteLine(f(1.9, 1.0));
        Console.ReadLine();
    }
