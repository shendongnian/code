    // delegate signature.
    // it's a bit simpler than the interface
    // definition.
    public delegate int Operation(int a, int b);
    // note that this is only a method.
    // it doesn't have to be static, btw.
    public static int Addition(int a, int b)
    {
        return a + b;
    }
 
    public static void Main()
    {
        Operation op = Addition;
        Console.WriteLine(op(1, 2));
    }
