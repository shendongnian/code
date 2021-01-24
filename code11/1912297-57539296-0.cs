    static void Main(string[] args)
            {
                //Rather than making a string you need to split into an array just start with one.
                string[] targetValues = { "One", "Two" };
    
                //You don't need to use Upper Case for String when creating a this list
                List<string> queryValues = new List<string>
                {
                    "One",
                    "Two",
                    "One",
                    "Two",
                    "Three",
                    "Four"
                };
    
                // Comparison done here
                List<string> results = queryValues.Where(x => targetValues.Contains(x)).ToList();
    
                // Seperating the list for the printout for easier viewing 
                Console.WriteLine(string.Join(", ", results));
            }
