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
----------
For comparison, this is the cps version not using async/await.
c#
    public static BigInteger Fib(int n)
    {
        var fib = Memo<int, BigInteger>((m, rec, cont) =>
        {
            if (m <= 1) cont(m);
            else rec(m - 1, x => rec(m - 2, y => cont(x + y)));
        });
        return fib(n);
    }
    [Test]
    public void Test()
    {
        Console.WriteLine(Fib(100000));
    }
    // ---------
    public static Func<X, Y> Memo<X, Y>(Action<X, Action<X, Action<Y>>, Action<Y>> func)
    {
        var memo = new Dictionary<X, Y>(); // can be a Lru cache
        var stack = new Stack<Action>();
        Action<X, Action<Y>> rec = null;
        rec = (x, cont) =>
        {
            stack.Push(() =>
            {
                Y res;
                if (memo.TryGetValue(x, out res))
                {
                    cont(res);
                }
                else
                {
                    func(x, rec, y =>
                    {
                        memo[x] = y;
                        cont(y);
                    });
                }
            });
        };
        return x =>
        {
            var res = default(Y);
            rec(x, y => res = y);
            while (stack.Count > 0)
            {
                var next = stack.Pop();
                next();
            }
            return res;
        };
    }
