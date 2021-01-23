        void Test()
        {
            using (var inputFile = File.OpenText(@"c:\in.txt"))
            {
                using (var outputFile = File.CreateText(@"c:\out.txt"))
                {
                    string current;
                    while ((current = inputFile.ReadLine()) != null)
                    {
                        outputFile.WriteLine(Process(current));
                    }
                }
            }
        }
        string Process(string current)
        {
            return current.ToLower();
        }
