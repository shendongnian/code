    class Program
    {
        static void Main()
        {
            using (var reader = File.OpenText("test.txt"))
            {
                foreach (var line in Parse(reader))
                {
                    Console.WriteLine(line);
                }
            }
        }
    
        public static IEnumerable<string> Parse(StreamReader reader)
        {
            string line;
            bool first = false;
            while ((line = reader.ReadLine()) != null)
            {
                if (!line.StartsWith("#"))
                {
                    if (first)
                    {
                        yield return line;
                    }
                }
                else if (!first)
                {
                    first = true;
                }
                else
                {
                    yield break;
                }
            }
        }
    }
