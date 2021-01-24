    static void Main(string[] args)
            {
                int x = 0;
    
                var r = new Random();
    
                for (var i = 0; i < 32; i++)
                {
                    x = x | (r.Next(0, 2) << i);
    
                }
    
                Console.WriteLine(x);
                Console.ReadKey();
            }
