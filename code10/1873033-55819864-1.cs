    class Program {
        static void Main(string[] args) {
            var ex = Expression.Lambda<Func<object>>(Expression.New(typeof(object))).Compile();
            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++) TestInvoke(ex);
            Console.WriteLine($"Invoke():\t\t{timer.Elapsed.ToString()}");
            timer = Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++) TestDynamicInvoke(ex);
            Console.WriteLine($"DynamicInvoke():\t{timer.Elapsed.ToString()}");
            Console.ReadKey(true);
        }
        static void TestInvoke(Func<object> func) {
            func();
        }
        static void TestDynamicInvoke(Delegate deleg) {
            deleg.DynamicInvoke();
        }
    }
