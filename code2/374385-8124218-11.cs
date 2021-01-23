    class Program
    {
        static void Main(string[] args)
        {
            RunTest();
        }
        private static void RunTest()
        {
            var parser = new ManualParser();
            string csv = Properties.Resources.Csv;
            var result = new StringBuilder();
            var s = new Stopwatch();
            for (int test = 0; test < 3; test++)
            {
                int lineCount = 0;
                s.Start();
                for (int i = 0; i < 1000000 / 50; i++)
                {
                    foreach (var line in csv.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                    {
                        string cur = line + s.ElapsedTicks.ToString();
                        result.AppendLine(parser.Parse(cur).ToString());
                        lineCount++;
                    }
                }
                s.Stop();
                Console.WriteLine("Completed {0} lines in {1}ms", lineCount, s.ElapsedMilliseconds);
                s.Reset();
                result = new StringBuilder();
            }
        }
    }
