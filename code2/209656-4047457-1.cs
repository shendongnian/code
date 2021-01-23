    public delegate double CalcFunc(double value);
    static class M
    {
        public static Func<T, S> Extend<T,S>(Func<T, S> functionToWrap)
        {
          return (someT) => functionToWrap(someT);
        }
    }
    class Program
    {
        private static double Calc(double input)
        {
            return 2*input;
        }
        [STAThread]
        static void Main()
        {
            Func<double, double> extended = M.Extend<double, double>(Calc);
            CalcFunc casted = (CalcFunc)Delegate.CreateDelegate(typeof(CalcFunc), extended.Target, extended.Method);
            Console.WriteLine(casted(2) + " == 4");
            Console.WriteLine("I didn't crash!");
            Console.ReadKey();
        }
    }
