    public static class Extensions
    {
        // Note extension methods need to be defined in a static class
        public static Func<T, V> Compose<T, U, V>(this Func<U, V> f, Func<T, U> g)
        {
            return x => f(g(x));
        }
    }
    public class CallingClass
    {
        public void CallingMethod()
        {
            Func<string, int> f1 = s => int.Parse(s);
            Func<int, double> f2 = i => i / 2.0;
            // Note which way round f1 and f2 go
            Func<string, double> composed = f2.Compose(f1);
            var result = composed("3");
            // Now result == 1.5
        }
    }
