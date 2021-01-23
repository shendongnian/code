        public static void Main()
        {
            string path = @"c:\oasis\B1.txt";
    
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Open the file to read from.
                string readText = File.ReadAllText(path);
                Console.WriteLine(readText);
            }
            
        }
