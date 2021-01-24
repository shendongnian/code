        static void Main(string[] args)
        {
            int cookie = 0;
            string cookieDetails = String.Empty;
            Console.WriteLine("Coockie Clicker, druk op spatie om te beginnen...");
            
            Console.Clear();
            while (cookie < 1000000)
            {
                
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                {
                    cookie++;
                    cookieDetails += ("Cookies =" + cookie + ",");
                    Console.WriteLine(cookieDetails);
                }
            }
        }
