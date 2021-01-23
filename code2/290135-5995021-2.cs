    public interface IArithmeticOperations<T>
    {
        T Sum(T a, T b);
        T Sub(T a, T b);
        T Div(T a, T b);
        T Mult(T a, T b);
        //
    }
    public class IntArithmetic : IArithmeticOperations<int>
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
        public int Sub(int a, int b)
        {
            return a - b;
        }
        public int Div(int a, int b)
        {
            return a / b;
        }
        public int Mult(int a, int b)
        {
            return a * b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int sum = Test.SumOfSquares(new[] {1, 2, 3}, new IntArithmetic());
        }
    }
    public static class Test
    {
        public static int SumOfSquares<T>(IEnumerable<T> sequence, IArithmeticOperations<T> summator)
        {
            // Do work
        }
    }
