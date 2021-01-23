    static void Main(string[] args)
    {
        Console.WriteLine(factorial(66));
    }
    public static int factorial(int n)
    {
        if (n == 1)
            return n;
        var result = n * factorial(n - 1);
        Console.WriteLine("{0} : {1}", n, result);
        return result;
    }
