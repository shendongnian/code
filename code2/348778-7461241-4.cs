    class Program {
        static bool DigitsOnly(string s) {
            int len = s.Length;
            for (int i = 0; i < len; ++i) {
                char c = s[i];
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
        static bool DigitsOnly2(string s) {
            foreach (char c in s) {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
        static bool DigitsOnly3(string s) {
            return s.All(c => c >= '0' && c <= '9');
        }
        static void Main(string[] args) {
            const string s1 = "916734184";
            const string s2 = "916734a84";
            const int iterations = 1000000;
            var sw = new Stopwatch();
            sw.Restart();
            for (int i = 0 ; i < iterations; ++i) {
                bool success = DigitsOnly(s1);
                bool failure = DigitsOnly(s2);
            }
            sw.Stop();
            Console.WriteLine(string.Format("DigitsOnly: {0}", sw.Elapsed));
            sw.Restart();
            for (int i = 0; i < iterations; ++i) {
                bool success = DigitsOnly2(s1);
                bool failure = DigitsOnly2(s2);
            }
            sw.Stop();
            Console.WriteLine(string.Format("DigitsOnly2: {0}", sw.Elapsed));
            sw.Restart();
            for (int i = 0; i < iterations; ++i) {
                bool success = DigitsOnly3(s1);
                bool failure = DigitsOnly3(s2);
            }
            sw.Stop();
            Console.WriteLine(string.Format("DigitsOnly3: {0}", sw.Elapsed));
            sw.Restart();
            for (int i = 0; i < iterations; ++i) {
                int dummy;
                bool success = int.TryParse(s1, out dummy);
                bool failure = int.TryParse(s2, out dummy);
            }
            sw.Stop();
            Console.WriteLine(string.Format("int.TryParse: {0}", sw.Elapsed));
            sw.Restart();
            var regex = new Regex("^[0-9]+$", RegexOptions.Compiled);
            for (int i = 0; i < iterations; ++i) {
                bool success = regex.IsMatch(s1);
                bool failure = regex.IsMatch(s2);
            }
            sw.Stop();
            Console.WriteLine(string.Format("Regex.IsMatch: {0}", sw.Elapsed));
        }
    }
