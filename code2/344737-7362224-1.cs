    public static class FunctionalExtensions
    {
        public static Func<T, V> Compose<T, U, V>(this Func<U, V> f, Func<T, U> g)
        {
            return x => f(g(x));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            Func<double, double> f = Square;
            Func<double, double> g = AddOne;
            var h = f.Compose(g); // This is a Func<double, double> now, (i.e. h(X) = f(g(x)) )
            double result = h(x);
        }
        public static double Square(double x)
        {
            return x * x;
        }
        public static double AddOne(double x)
        {
            return x + 1;
        }
    }
   
