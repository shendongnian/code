    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                double x = Math.Cos(3.14);
                double y = 3.14;
                Console.WriteLine(y.Cos());
            }
        }
    
        public static class Extention
        {
            public static double Cos(this double d)
            {
                return Math.Cos(d);
            }
        }
    }
