    class Program
    {
    private static int Sum(int a, int b)
    {
        return a + b;
    }
    
    private static int Multiply(int a, int b)
    {
        return a * b;
    }
    
    
    private static int GetResult(Func<int, int, int> solver, int a, int b)
    {
        try {
          return solver(a, b);
        } catch {
        }
        return 0; // your default return
    }
    
    static void Main(string[] args)
    {
        var a = 2;
        var b = 3;
    
        var sum = GetResult(Sum, a, b);
        var multiply = GetResult(Multiply, a, b);
    }
