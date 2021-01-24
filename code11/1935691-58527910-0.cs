    class Program
    {
        static void Main(string[] args)
        {
            var firstVar = 1;
            var secondVar = 2;
            true.SetValue(ref firstVar, ref secondVar);
            false.SetValue(ref secondVar, ref secondVar);
            Console.Read();
        }
    }
    public static class BoolExtensions
    {
        public static void SetValue(this bool bVal, ref int first, ref int second)
        {
            if (bVal)
                first = 10;
            else
                second = 10;
        }
    }
