    //Circle
    static double Pole(int x, double y)
    {
        return y(x * x);
    }
    //Square
    static double Pole(int x)
    {
        return x * x;
    }
    //Rectangle
    static double Pole(int x, int y)
    {
        return x * y;
    }
    //Triangle
    static double Pole(int x, int y, int z)
    {
        return x * y / z;
    }
    //Trapezoid
    static double Pole(int x, int y, int v, int z)
    {
        return (x + y) / z * v;
    }
    static void Main(string[] args)
    {
        int x = 2;
        double y = 3.14;
        Console.WriteLine(Pole(x, y));
        Console.ReadKey();
    }
