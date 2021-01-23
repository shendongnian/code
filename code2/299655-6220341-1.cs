        public static void Main()
        {
            string path = @"c:\oasis\B1.txt";
            try {
                // Open the file to read from.
                string readText = System.IO.File.ReadAllText(path);
                Console.WriteLine(readText);
            }
            catch (System.IO.FileNotFoundException fnfe) {
                // Handle file not found.  
            }
            
        }
