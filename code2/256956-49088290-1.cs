        public void TestInConsole(string[] args)
        {
            Console.WriteLine($"Service starting...");
            this.OnStart(args);
            Console.WriteLine($"Service started. Press any key to stop.");
            Console.ReadKey();
            Console.WriteLine($"Service stopping...");
            this.OnStop();
            Console.WriteLine($"Service stopped. Closing in 5 seconds.");
            System.Threading.Thread.Sleep(5000);
        }
