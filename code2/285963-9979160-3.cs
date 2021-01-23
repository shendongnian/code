    class SplitAnalyser
    {
        public static bool stopProcessor = false;
        public static bool Terminate = false;
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Split Analyser starts");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press Esc to quit.....");
            Thread MainThread = new Thread(new ThreadStart(startProcess));
            Thread ConsoleKeyListener = new Thread(new ThreadStart(ListerKeyBoardEvent));
            MainThread.Name = "Processor";
            ConsoleKeyListener.Name = "KeyListener";
            MainThread.Start();
            ConsoleKeyListener.Start();
           
            while (true) 
            {
                if (Terminate)
                {
                    Console.WriteLine("Terminating Process...");
                    MainThread.Abort();
                    ConsoleKeyListener.Abort();
                    Thread.Sleep(2000);
                    Thread.CurrentThread.Abort();
                    return;
                }
                if (stopProcessor)
                {
                    Console.WriteLine("Ending Process...");
                    MainThread.Abort();
                    ConsoleKeyListener.Abort();
                    Thread.Sleep(2000);
                    Thread.CurrentThread.Abort();
                    return;
                }
            } 
        }
        public static void ListerKeyBoardEvent()
        {
            do
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                {
                    Terminate = true;
                }
            } while (true); 
        }
        
        public static void startProcess()
        {
            int i = 0;
            while (true)
            {
                if (!stopProcessor && !Terminate)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Processing...." + i++);
                    Thread.Sleep(3000);
                }
                if(i==10)
                    stopProcessor = true;
                
            }
        }
    }
