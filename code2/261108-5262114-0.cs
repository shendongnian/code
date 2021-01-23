        static public void ListProcesses(Object stateInfo)
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
            }
        }
        static void Main(string[] args)
        {
            //create a callback to our worker method
            TimerCallback callback = new TimerCallback(ListProcesses);
            // create a one minute timer tick
            Timer stateTimer = new Timer(callback, null, 0, 60000);
            // loop here forever
            while (true)
            {
                //sleep every second so we dont hog the cpu
                Thread.Sleep(1000);
                //add program control logic
                //if we want to exit the program with anything other than closing the window
            }
        }
