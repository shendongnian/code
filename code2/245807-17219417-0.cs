    static void Main(string[] args)
        {
            int loopCount = 1000000; // 1,000,000 (one million) iterations
            var timer = new Timer();
            timer.Restart();
            for (int i = 0; i < loopCount; i++)
                Log(MethodBase.GetCurrentMethod(), "whee");
            TimeSpan reflectionRunTime = timer.CalculateTime();
            timer.Restart();
            for (int i = 0; i < loopCount; i++)
                Log((Action<string[]>)Main, "whee");
            TimeSpan lookupRunTime = timer.CalculateTime();
            Console.WriteLine("Reflection Time: {0}ms", reflectionRunTime.TotalMilliseconds);
            Console.WriteLine("    Lookup Time: {0}ms", lookupRunTime.TotalMilliseconds);
            Console.WriteLine();
            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
        public static void Log(Delegate info, string message)
        {
            // do stuff
        }
        public static void Log(MethodBase info, string message)
        {
            // do stuff
        }
        public class Timer
        {
            private DateTime _startTime;
            public void Restart()
            {
                _startTime = DateTime.Now;
            }
            public TimeSpan CalculateTime()
            {
                return DateTime.Now.Subtract(_startTime);
            }
        }
