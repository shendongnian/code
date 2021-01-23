    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"int.MinValue  = {Convert.ToString(int.MinValue, 2)}");
            Console.WriteLine($"long.MinValue = {Convert.ToString(long.MinValue, 2)}");
            Console.WriteLine();
            long cast1 = int.MinValue;                   // !!!
            long cast2 = unchecked((uint)int.MinValue);  // !!!
            Console.WriteLine($"default cast = {Convert.ToString(cast1, 2)}");
            Console.WriteLine($"custom  cast = {Convert.ToString(cast2, 2)}");
            Console.WriteLine();
            Console.WriteLine($"default long OR int = {Convert.ToString(long.MinValue | int.MinValue, 2)}");
            Console.WriteLine($"custom  long OR int = {Convert.ToString(long.MinValue | unchecked((uint)int.MinValue), 2)}");
    }
    }
