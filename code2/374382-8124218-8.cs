    class Program
    {
        static void Main(string[] args)
        {
            var parser = new ManualParser();
            string csv = Properties.Resources.Csv;
            var result = new StringBuilder();
            var s = new Stopwatch();
            int lineCount = 0;
            s.Start();
            for (int i = 0; i < 3000; i++)
            {
                foreach (var line in csv.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    result.AppendLine(parser.Parse(line).ToString());
                    lineCount++;
                }
            }
            s.Stop();
            Console.WriteLine("Completed {0} lines in {1}ms", lineCount, s.ElapsedMilliseconds);
        }
    }
