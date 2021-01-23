    class Program
    {
        static void Main(string[] args)
        {
            Parallel.ForEach(args, file =>
            {
                using (var stream = File.OpenRead(file))
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null) 
                    {
                        ProcessLine(line);
                    }
                }
            });
        }
    
        static void ProcessLine(string line)
        {
            // TODO: process the line
        }
    }
