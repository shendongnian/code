    static ulong Fibonacci(int n, IList<ulong> stack)
    {
        ulong fibonacci;
        if (n <= 1)
        {
            fibonacci = (ulong)n;
        }
        else
        {
            ulong n1, n2;
            if (n < stack.Count)
                n1 = stack[n - 1];
            else
                n1 = Fibonacci(n - 1, stack);
            if (n - 1 < stack.Count)
                n2 = stack[n - 2];
            else
                n2 = Fibonacci(n - 2, stack);
            fibonacci = n1 + n2;
        }
        if (n >= stack.Count)
            stack.Add(fibonacci);
        return fibonacci;
    }
    static void PrintAllFibonacci()
    {
        var stack = new List<ulong>();
        var n = 0;
        while(n < 50)
            Console.WriteLine(n + ") " + Fibonacci(n++, stack));
    }
