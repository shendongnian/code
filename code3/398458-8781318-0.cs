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
            while ((line = reader.ReadLine()) != null)
            {
                if (!line.StartsWith("#"))
                {
                    yield return line;
                }
            }
        }
    }
