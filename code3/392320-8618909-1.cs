    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine(GetNumber(12));
        }
        public static string GetNumber(int length) {
            var rng = new Random(Environment.TickCount);
            return string.Concat(Enumerable.Range(0, length).Select((index) => rng.Next(10).ToString()));
        }
    }
