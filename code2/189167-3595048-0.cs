    namespace MyLibrary
    {
        public class MyMath
        {
            // Be aware of the virtual keyword which enables overriding the method
            public virtual int Summmator(int a, int b)
            {
                return a + b;
            }
            public int SimpleMultiplicator(int a, int b)
            {
                int result = 0;
                for (int i = 0; i < b; i++)
                {
                    result = Summmator(result, a);
                }
            }
        }
    }
    namespace MyProgram
    {
        using MyLibrary;
        public class MyExtendedMath : MyMath
        {
            public override int Summmator(int a, int b)
            {
                return a + 2 * b;
            }
        }
        public static class Program
        {
            public static void Main()
            {
                MyMath math = new MyExtendedMath();
                int result = math.SimpleMultiplicator(2, 3);
                Console.WriteLine(result);
            }
        }
    }
