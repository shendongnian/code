    static void Main(string[] args)
            {
                int cookie = 0;
                Console.WriteLine("Coockie Clicker, druk op spatie om te beginnen...");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();
                while (cookie < 1000000)
                {
                    
    
                    if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        cookie++;
                        Console.WriteLine("Cookies =" + cookie);
                    }
                    else
                    {
    
                    }
                    keyInfo = Console.ReadKey();
    
                }
            }
