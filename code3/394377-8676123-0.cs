    class MyExampleApp : ServiceBase
    {
    
        public static void Main(string[] args)
        {
            if (args.Length == 1 && args[0].Equals("--console"))
            {
                new MyExampleApp().ConsoleRun();
            }
            else
            {
                ServiceBase.Run(new MyExampleApp());
            }
        }
        private void ConsoleRun()
        {
            Console.WriteLine(string.Format("{0}::starting...", GetType().FullName));
    
            OnStart(null);
    
            Console.WriteLine(string.Format("{0}::ready (ENTER to exit)", GetType().FullName));
            Console.ReadLine();
    
            OnStop();
    
            Console.WriteLine(string.Format("{0}::stopped", GetType().FullName));
        }
        //snip
    }
