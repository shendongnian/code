    public static class Cleanup
    {
        static Cleanup()
        {
            // Register handler to ProcessExit event
            AppDomain.CurrentDomain.ProcessExit += ProcessExitHandler;
        }
        /// <summary>
        /// This method is invoked before the process exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ProcessExitHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Cleanup here!");
        }
        /// <summary>
        /// Some method needs to be invoked in order to register the ProcessExitHanlder
        /// </summary>
        public static void DoSomenthing()
        {
        }
        
    }
