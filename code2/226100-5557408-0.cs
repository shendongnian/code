    using System.Diagnostics;
    public static class TestExtensions
    {
        public static void TimedOpen(this SqlConnection conn)
        {
            Stopwatch sw = Stopwatch.StartNew();
            conn.Open();
            Console.WriteLine(sw.Elapsed);
        }
    }
