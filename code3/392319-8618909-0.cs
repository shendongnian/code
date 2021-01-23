    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine(GetNumber(7));
            Console.WriteLine(GetNumber(8));
            Console.WriteLine(GetNumber(12));
            Console.WriteLine(GetNumber(500));
        }
        public static string GetNumber(int length) {
            return string.Concat(RandomDigits().Take(length));
        }
        public static IEnumerable<int> RandomDigits() {
            var rng = new Random(System.Environment.TickCount);
            while (true) yield return rng.Next(10);
        }
    }
