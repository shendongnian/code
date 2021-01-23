        public static IEnumerable<string> GetFileLines(string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                using (var reader = new StreamReader(stream))
                {
                    reader.ReadLine(); // skip one line
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        yield return line;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            foreach (var line in GetFileLines("C:\\yourfile.txt"))
            {
                // do something with the line here.
            }
        }
