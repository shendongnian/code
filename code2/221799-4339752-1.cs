        static void Main(string[] args)
        {
            foreach (IEnumerable<string> batch in ReadBatches("data.txt"))
            {
                Console.WriteLine("*** Processing Batch ***");
                foreach (var item in batch)
                {
                    Console.WriteLine(item);
                }
            }                      
        }
