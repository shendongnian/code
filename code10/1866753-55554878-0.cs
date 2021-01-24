    class Program
    {
        static int[] occurence(string pattern)
        {
            int[] table = new int[char.MaxValue];
            for (char a = (char)0; a < char.MaxValue; a++)
            {
                table[(int)a] = -1;
            }
            for (int i = 0; i < pattern.Length; i++)
            {
                char a = pattern[i];
                table[(int)a] = i;
            }
            return table;
        }
        public static int Sunday(string text, string pattern)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int k = 0;
            int i = 0;
            int[] table = occurence(pattern);
            while (i <= text.Length - pattern.Length)
            {
                int j = 0;
                while (j < pattern.Length && text[i + j] == pattern[j])
                {
                    j++;
                }
                if (j == pattern.Length)
                {
                    k++;
                }
                i += pattern.Length;
                if (i < text.Length)
                {
                    i -= table[(int)text[i]];
                }
            }
            timer.Stop();
            Console.WriteLine(timer.Elapsed);
            return k;
        }
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"C:\Users\Bacho\Desktop\Studies\Advanced Algorithms\Test Patterns\Book1.txt");
            string pattern = "frankenstein";
            Console.WriteLine(Sunday(text, pattern));
        }
    }
