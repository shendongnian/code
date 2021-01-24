    class Program {
        private static Random Random;
        private static Stopwatch Stopwatch;
        static void Main(string[] args) {
            Random = new Random(Guid.NewGuid().GetHashCode());
            Stopwatch = new Stopwatch();
            decimal forLoop = 0;
            decimal linq = 0;
            for (int i = 0; i < 1000000; i++) {
                string s = RandomString(100);
                Stopwatch.Restart();
                s.CountTrailingSpaces();
                Stopwatch.Stop();
                forLoop += Stopwatch.ElapsedTicks;
                Stopwatch.Restart();
                s.CountTrailingSpacesLinq();
                Stopwatch.Stop();
                linq += Stopwatch.ElapsedTicks;
            }
            Console.WriteLine($"For:\t{forLoop}");
            Console.WriteLine($"Linq:\t{linq}");
        }
        private static string RandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789          ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
    public static class StringExtensions {
        public static int CountTrailingSpaces(this string s) {
            int count = 0;
            for (int i = s.Length - 1; i >= 0; i--) {
                if (Char.IsWhiteSpace(s[i])) {
                    count++;
                }
                else {
                    return count;
                }
            }
            return count;
        }
        public static int CountTrailingSpacesLinq(this string s) {
            return s.Reverse().TakeWhile(Char.IsWhiteSpace).Count();
        }
    }
