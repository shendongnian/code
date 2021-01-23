    namespace MyLibrary
    {
        public interface ISummmator
        {
            int Summmator(int a, int b);
        }
        public class Summmator : ISummator
        {
            public int Summmator(int a, int b)
            {
                return a + b;
            }
        }
        public static class MyMath
        {
            public static int SimpleMultiplicator(int a, int b, ISummmator summmator)
            {
                int result = 0;
                for (int i = 0; i < b; i++)
                {
                    result = summmator.Summmator(result, a);
                }
            }
        }
    }
    namespace MyProgram
    {
        using MyLibrary;
        public class MySummmator : ISummmator
        {
            public int Summmator(int a, int b)
            {
                return a + 2 * b;
            }
        }
        public static class Program
        {
            public static void Main()
            {
                int result = MyMath.SimpleMultiplicator(2, 3, new MySummmator());
                Console.WriteLine(result);
            }
        }
    }
