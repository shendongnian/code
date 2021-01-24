    class Program
    {
        static void Main(string[] args)
        {
            // warm up
            Test1<Class1>(0);
            Test2<int, Class1>(0);
            const int numiter = 10000;
            var sw1 = Stopwatch.StartNew();
            for (int i = 0; i < numiter; i++)
                Test1<Class1>(i);
            sw1.Stop();
            Console.WriteLine($"With Activator.CreateInstance: " +
                $"{(double)sw1.ElapsedTicks / numiter} ticks per object");
            var sw2 = Stopwatch.StartNew();
            for (int i = 0; i < numiter; i++)
                Test2<int, Class1>(i);
            sw2.Stop();
            Console.WriteLine($"With Expression.Compile: " +
                $"{(double)sw2.ElapsedTicks / numiter} ticks per object");
            var sw3 = Stopwatch.StartNew();
            var creator = CreateCreator<int, Class1>();
            for (int i = 0; i < numiter; i++)
                creator(i);
            sw3.Stop();
            Console.WriteLine($"With cached Expression.Compile: " +
                $"{(double)sw3.ElapsedTicks / numiter} ticks per object");
        }
        static public object Test1<T>(params object[] parameters)
        {
            var instance = (T)Activator.CreateInstance(
                typeof(T), BindingFlags.Instance | BindingFlags.Public, null, parameters, null);
            return instance;
        }
        static Func<TArg, T> CreateCreator<TArg, T>()
        {
            var constructor = typeof(T).GetConstructor(new Type[] { typeof(TArg) });
            var parameter = Expression.Parameter(typeof(TArg), "p");
            var creatorExpression = Expression.Lambda<Func<TArg, T>>(
                Expression.New(constructor, new Expression[] { parameter }), parameter);
            return creatorExpression.Compile();
        }
        static public object Test2<TArg, T>(TArg arg)
        {
            var creator = CreateCreator<TArg, T>();
            return creator(arg);
        }
    }
