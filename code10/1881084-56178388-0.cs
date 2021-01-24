c#
    // Core algorithm using the cute async/await syntax
    // (n.b. this would be exponential without memoization.)
    private static async Task<BigInteger> FibAux(int n)
    {
        if (n <= 1) return n;
        return await Rec(n - 1) + await Rec(n - 2);
    }
    public static Func<int, Task<BigInteger>> Rec { get; }
        = Utils.StackSafeMemoize<int, BigInteger>(FibAux);
        
    public static BigInteger Fib(int n)
        => FibAux(n).Result;
    [Test]
    public void Test()
    {
        Console.WriteLine(Fib(100000));
    }
    public static class Utils
    {
        // the combinator (still using the thread pool for execution)
        public static Func<X, Task<Y>> StackSafeMemoize<X, Y>(Func<X, Task<Y>> func)
        {
            var memo = new Dictionary<X, Y>();
            return x =>
            {
                Y result;
                if (!memo.TryGetValue(x, out result))
                {
                    return Task.Run(() => func(x).ContinueWith(task =>
                    {
                        var y = task.Result;
                        memo[x] = y;
                        return y;
                    }));
                }
                return Task.FromResult(result);
            };
        }
    } 
