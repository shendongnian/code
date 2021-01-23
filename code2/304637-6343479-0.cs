    void checkProcess()
    {
        Process[] processes = Process.GetProcessesByName("NameOfProcess");
        if (processes.Length == 0)
        {
             // No such process
        }
        else
        {
             foreach (Process proc in processes)
             {
                // do something with proc
             }
        }
    }
