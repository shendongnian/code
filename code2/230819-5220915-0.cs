    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch Chrono = Stopwatch.StartNew();
            if (false & Verifier())
                Console.WriteLine("OK");
            Chrono.Stop();
            Console.WriteLine(Chrono.Elapsed);
            Chrono.Restart();
            if (false && Verifier())
                Console.WriteLine("OK");
            Chrono.Stop();
            Console.WriteLine(Chrono.Elapsed);
        }
        public static bool Verifier()
        {
            // Long test
            Thread.Sleep(2000);
            return true;
        }
    }
