    class Program
    {
      double value = 33;
        static void Main()
        {
            Program p = new Program();
            p.ParentFunction();
        }
        void ParentFunction()
        {
            double x = 1.0;
            for (int i = 0; i <= 10; i++)
            {
                double res = calc(ref value, x);
                Console.WriteLine(res);
            }
        }
        double calc(ref double val, double roc)
        {
            double c = 0;
            c = val - roc;
            val -= 1;
            return c;
        }
    }
