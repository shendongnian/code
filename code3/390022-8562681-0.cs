    class Program
    {
        private static DateTime userInputTimeout;
        static void Main(string[] args)
        {
            userInputTimeout = DateTime.Now.AddSeconds(30); // users have 30 seconds before automated procedures begin
            Thread userInputThread = new Thread(new ThreadStart(DoUserInput));
            userInputThread.Start();
            while (DateTime.Now < userInputTimeout)
                Thread.Sleep(500);
            userInputThread.Abort();
            userInputThread.Join();
            DoAutomatedProcedures();
        }
        private static void DoUserInput()
        {
            try
            {
                Console.WriteLine("User input ends at " + userInputTimeout.ToString());
                Console.WriteLine("Type a command and press return to execute");
                string command = string.Empty;
                while ((command = Console.ReadLine()) != string.Empty)
                    ProcessUserCommand(command);
                Console.WriteLine("User input ended");
            }
            catch (ThreadAbortException)
            {
            }
        }
        private static void ProcessUserCommand(string command)
        {
            Console.WriteLine(string.Format("Executing command '{0}'",  command));
        }
        private static void DoAutomatedProcedures()
        {
            Console.WriteLine("Starting automated procedures");
            //TODO: enter automated code in here
        }
    }
