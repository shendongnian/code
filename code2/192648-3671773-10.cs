    static T F<M, T>(M m, T x) where M : Num<T>
    {
        return m.Multiply(x, m.Multiply(x, x));
    }
    static void Main(string[] args)
    {
        Console.WriteLine(F(Int.Instance, 5));  // prints "125"
    }
