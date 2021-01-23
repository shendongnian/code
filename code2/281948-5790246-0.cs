    class Program
    {
        const int num = 10000000;
        static void Main(string[] args)
        {
            for (int run = 1; run <= 5; run++)
            {
                Console.WriteLine("Run " + run);
                RunTest1();
                RunTest2();
            }
            Console.ReadLine();
        }
        static void RunTest1()
        {
            Console.WriteLine("Test1");
            var t = new Test1();
            var sw = Stopwatch.StartNew();
            double x = 0;
            for (var i = 0; i < num; i++)
            {
                t.CalculusMaster(x);
                x += 1.0;
            }
            sw.Stop();
            Console.WriteLine("Total time for " + num + " iterations: " + sw.ElapsedMilliseconds + " ms");
        }
        static void RunTest2()
        {
            Console.WriteLine("Test2");
            var t = new Test2();
            var sw = Stopwatch.StartNew();
            double x = 0;
            for (var i = 0; i < num; i++)
            {
                t.CalculusMaster(x);
                x += 1.0;
            }
            sw.Stop();
            Console.WriteLine("Total time for " + num + " iterations: " + sw.ElapsedMilliseconds + " ms");
        }
    }
    class Test1 
    {
        int y;
        Func<double, double> f1;
        Func<double, double> f2;
        Func<double, double> f3;
        public Test1()
        {
            this.y = 10;
            this.f1 = (x => 25 * x + y);
            this.f2 = (x => f1(x) + y * f1(x));
            this.f3 = (x => Math.Log(f2(x) + f1(x)));
        }
        public double CalculusMaster(double x)
        {
            return f3(x) + f2(x);
        }
    }
    class Test2
    {
        int y;
        
        public Test2()
        {
            this.y = 10;
        }
        private double f1(double x)
        {
            return 25 * x + y;
        }
        private double f2(double x)
        {
            return f1(x) + y * f1(x);
        }
        private double f3(double x)
        {
            return Math.Log(f2(x) + f1(x));
        }
        public double CalculusMaster(double x)
        {
            return f3(x) + f2(x);
        }
    }
