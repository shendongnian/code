    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Start at {DateTime.Now}");
            Console.ReadKey();
            Console.WriteLine(A.LazyString);
            Console.ReadKey();
            Console.WriteLine(A.LazyString);
            Console.ReadKey();
        }
    }
    public class A
    {
        public static readonly String LazyString = CalculateString();
        private static string CalculateString()
        {
            return DateTime.Now.ToString();
        }
    }
