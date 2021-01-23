    private static void Main(string[] args)
    {
        NoReturnValue((i) =>
            {
                // work here...
                Console.WriteLine(i);
            });
        var value = ReturnSometing((i) =>
            {
                // work here...
                return i > 0;
            });
    }
    
    private static void NoReturnValue(Action<int> foo)
    {
        // work here to determind input to foo
        foo(0);
    }
    
    private static T ReturnSometing<T>(Func<int, T> foo)
    {
        // work here to determind input to foo
        return foo(0);
    }
