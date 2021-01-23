    public interface ISummator<T>
    {
        T Sum(T a, T b);
    }
    public class IntSummator : ISummator<int>
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int sum = Test.Sum(new[] {1, 2, 3}, new IntSummator());
        }
    }
    public static class Test
    {
        public static int Sum<T>(IEnumerable<T> sequence, ISummator<T> summator)
        {
            // Do work
        }
    }
