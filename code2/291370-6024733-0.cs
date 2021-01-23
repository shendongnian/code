    class Program
    {
        static void Main(string[] args)
        {
            var now = DateTime.Now;
            var dates = new DateTime[5000000];
            for (int i = 0; i < dates.Length; i++)
                dates[i] = now.AddSeconds(i);
            for (int i = 0; i < 5; i++)
            {
                Test("Test1", () =>
                {
                    var result = new object[dates.LongLength];
                    for (long l = 0; l < result.LongLength; l++)
                        result[l] = dates[l];
                    return result;
                });
                Test("Test2", () =>
                {
                    var result = new object[dates.LongLength];
                    dates.CopyTo(result, 0);
                    return result;
                });
                Test("Test3", () =>
                {
                    var result = new object[dates.LongLength];
                    Array.Copy(dates, result, dates.LongLength);
                    return result;
                });
                Test("Test4", () =>
                {
                    var result = Array.ConvertAll(dates, d => (object)d);
                    return result;
                });
                Test("Test5", () =>
                {
                    var result = dates.Cast<object>().ToArray();
                    return result;
                });
                Test("Test6", () =>
                {
                    var result = dates.Select(d => (object)d).ToArray();
                    return result;
                });
                Console.WriteLine();
            }
        }
        static void Test<T>(string name, Func<T> fn)
        {
            var startMem = GC.GetTotalMemory(true);
            var sw = Stopwatch.StartNew();
            var result = fn();
            sw.Stop();
            var endMem = GC.GetTotalMemory(false);
            var diff = endMem - startMem;
            Console.WriteLine("{0}\tMem: {1,7}/{2,7} ({3,7})", name, startMem, endMem, diff);
            Console.WriteLine("\tTime: {0,7} ({1,7})", sw.ElapsedMilliseconds, sw.ElapsedTicks);
        }
    }
