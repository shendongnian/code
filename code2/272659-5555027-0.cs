       class Program
        {
            static void Main(string[] args)
            {
                string data = "aaaa 12312 <asdad> 12334 </asdad>";
        
                Regex reg = new Regex("[0-9]+");
        
                foreach (var match in reg.Matches(data))
                {
                    Console.WriteLine(match);
                }
        
                Console.ReadLine();
            }
        }
