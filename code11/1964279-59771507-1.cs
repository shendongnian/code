            static void Main(string[] args)
        {
            Console.Title = $"Process #{Process.GetCurrentProcess().Id} (logger additional)";
            {
                Console.WriteLine("New additionnal app started... " + Process.GetCurrentProcess().Id);
                var line = Console.In.ReadLine();
                Process.GetCurrentProcess().Kill();
            }
        }
