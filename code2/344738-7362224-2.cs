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
            Func<double, double> 
                f1 = Square,         // Func<double, double> is a delegate type so we have to create
                g1 = AddOne,         // an instance for both f and g
                h1 = f1.Compose(g1); // This is a Func<double, double> now, (i.e. h(X) = f(g(x)) )
            // To call new function do this
            double result1 = h1(5.0);
            Func<double, double>
                f2 = x => x*x,       
                g2 = x => x + 1,       
                h2 = f2.Compose(g2);
            // To call new function do this
            double result2 = h2(5.0);
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
