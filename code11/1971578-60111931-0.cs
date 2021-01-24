    class Program
    {
        private static void MemoryPoolTest(Span<long> span)
        {
            for (var i = 0; i < 100; i++)
            {
                var innerCounter = 0;
                for (var j = 0; j < 1000; j++)
                {
                    if (j % 3 == 0)
                    {
                        span[innerCounter++] = DateTime.UtcNow.Ticks;
                    }
                }
                var result = span.Slice(0, innerCounter - 1);
            }
        }
        private static void ArrayTest()
        {
            for (var i = 0; i < 100; i++)
            {
                var innerCounter = 0;
                Span<long> array = new long[1000];
                for (var j = 0; j < 1000; j++)
                {
                    if (j % 3 == 0)
                    {
                        array[innerCounter++] = DateTime.UtcNow.Ticks;
                    }
                }
                var result = array.Slice(0, innerCounter - 1);
            }
        }
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var m = new List<long>();
            var a = new List<long>();
            var sw = new Stopwatch();
            using var owner = MemoryPool<long>.Shared.Rent(1000);
            var span = owner.Memory.Span;
            for (var i = 0; i < 1000; i++)
            {
                sw.Restart();
                MemoryPoolTest(span);
                sw.Stop();
                m.Add(sw.ElapsedTicks);
                sw.Restart();
                ArrayTest();
                sw.Stop();
                a.Add(sw.ElapsedTicks);
            }
            Console.WriteLine(m.Skip(10).Average());
            Console.WriteLine(a.Skip(10).Average());
        }
    }
