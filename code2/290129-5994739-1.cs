    public static int Addition(int a, int b)
    {
        return a+b;
    }
 
    public delegate int Operation(int a, int b);
    public static void Main()
    {
        Operation op = Addition;
        Console.WriteLine(op(1, 2));
    }
