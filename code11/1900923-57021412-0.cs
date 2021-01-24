    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                foreach (var item in Process.GetProcesses())
                {
                    /*Kills all chrome.exe processes*/
                    /*Replace chrome with the process you want to kill*/
                    if (item.ProcessName == "chrome")
                    {
                        //Kills the process
                        item.Kill();
                    }
                }
            }
        }
    }
