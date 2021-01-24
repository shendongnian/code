    class Program
    {
        static void Main()
        {
            double x = 1.0;
            double res = 33;
            calc(res, x);
        }
        static void calc(double val, double roc)
        {
            Console.WriteLine(val);
            if (val == 1)
                return;
            val = val - roc;
            calc(val, roc);
        }
    }
