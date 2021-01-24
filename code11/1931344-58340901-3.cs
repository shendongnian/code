    using System;
    using System.Diagnostics;
    using System.Threading;
    namespace ConsoleApp1
    {
        class Program
        {
            public static void Main()
            {
                // Note how we apply the parameters here, even though the 
                // function is actually called inside TimeFunction().
                var result = TimeFunction(() => functionToTime(1, 2.0, "3"));
                Console.WriteLine("Result = "   + result.value);
                Console.WriteLine("Duration = " + result.duration);
            }
            static string functionToTime(int intVal, double doubleVal, string stringVal)
            {
                Thread.Sleep(250);
                return $"intVal = {intVal}, doubleVal = {doubleVal}, stringVal = {stringVal}";
            }
            public static (TimeSpan duration, T value) TimeFunction<T>(Func<T> func)
            {
                var sw = Stopwatch.StartNew();
                var result = func();
                return (sw.Elapsed, result);
            }
        }
    }
