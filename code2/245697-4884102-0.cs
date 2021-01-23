    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            string r;
            int iter = 10000;
            string[] values = { "a", "b", "c", "d", "a little bit longer please", "one more time" };
            sw.Restart();
            for (int i = 0; i < iter; i++)
                r = Program.StringJoin(",", values);
            sw.Stop();
            Console.WriteLine("string.Join ({0} times): {1}ms", iter, sw.ElapsedMilliseconds);
            sw.Restart();
            for (int i = 0; i < iter; i++)
                r = Program.StringBuilderAppend(",", values);
            sw.Stop();
            Console.WriteLine("StringBuilder.Append ({0} times): {1}ms", iter, sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
        static string StringJoin(string seperator, params string[] values)
        {
            return string.Join(seperator, values);
        }
        static string StringBuilderAppend(string seperator, params string[] values)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(values[0]);
            for (int i = 1; i < values.Length; i++)
            {
                builder.Append(seperator);
                builder.Append(values[i]);
            }
            return builder.ToString();
        }
    }
