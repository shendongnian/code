    class Program
    {
        static void Main(string[] args)
        {
            Start();
            Console.ReadLine();                
        }
        static int TESTS = 10;
        static int LOOPS = 50000;
        static double d1 = 1.5530000000000002;
        static double d2 = 1.5531;
        static double dResult;
        static int iResult;
        static decimal cResult;
        static void Start()
        {
            // actual test
            for (int x = 0; x < TESTS; x++)
            {
                Stopwatch sw = new Stopwatch();
                long tick1, tick2, tick3;
                sw.Start();
                for (int j = 0; j < LOOPS; j++)
                {
                    dResult = Math.Round(d1 / 2.0, 4);
                    dResult = Math.Round(d2 / 2.0, 4);
                }
                sw.Stop();
                tick1 = sw.ElapsedTicks;
                sw.Restart();
                for (int j = 0; j < LOOPS; j++)
                {
                    iResult = (int)(d1 / 2.0 * 10000.0);
                    iResult = (int)(d2 / 2.0 * 10000.0);
                }
                sw.Stop();
                tick2 = sw.ElapsedTicks;
                sw.Restart();
                for (int j = 0; j < LOOPS; j++)
                {
                    cResult = decimal.Round((decimal)d1, 4);
                    cResult = decimal.Round((decimal)d2, 4);
                }
                sw.Stop();
                tick3 = sw.ElapsedTicks;
                Console.WriteLine("Math {0} Int {1} Decimal {2}", tick1, tick2, tick3);
            }
        }
    }
