    class Program
        {
            static void Main(string[] args)
            {
                string original = "some text, some other text";
    
                string processed = original.Replace(",", "\";\"");
    
                Console.WriteLine(processed);
                
                Console.ReadKey();
            }
        }
