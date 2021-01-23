    Process[] myProcList = Process.GetProcesses();
    for (int i = 0; i <= myProcList.Length - 1; i ++) {
        string strProcessName = myProcList [i].ProcessName;
        string strProcessTitle = myProcList [i].MainWindowTitle();
             //check for your process name. 
        if (strProcessName.ToLower().Trim().Contains("access")) {
           myProcList [i].Kill();
        }
    }
