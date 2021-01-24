    //Circle
    static double Pole(int x, double y)
    {
        if(y != 3.14)
            y = 3.14;
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
        if(z != 2)
            z = 2;
        return x * y / z;
    }
    //Trapezoid
    static double Pole(int x, int y, int v, int z)
    {
        if(z != 2)
            z = 2;
  
        return (x + y) / z * v;
    }
    static void Main(string[] args)
    {
        int x = 2;
        double y = 3.14;
        Console.WriteLine(Pole(x, y));
        Console.ReadKey();
    }
