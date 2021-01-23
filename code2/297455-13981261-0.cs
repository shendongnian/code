    static void Main()
            {
                string[] testArray = new string[]
                {
                    "aa",
                    "ab",
                    "ac",
                    "ad",
                    "ab",
                    "af"
                };
    
                Array.Sort(testArray, StringComparer.InvariantCulture);
    
                Array.ForEach(testArray, x => Console.WriteLine(x));
            }
