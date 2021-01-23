    public ApplicationState AppState
    {
        get
        {
            Process[] processCollection = Process.GetProcessesByName(ProcessName);
            if(processCollection != null && processCollection.Length  >= 1 && 
                processCollection[0] != null)
            {
                IntPtr activeWindowHandle = Win32.GetForegroundWindow();
                //Optional int ProcessID;
                //Optional Win32.GetWindowThreadProcessId(GetForegroundWindow(),out ProcessID)
                foreach(Process wordProcess in processCollection)
                {
                    //Optional if( ProcessID == wordProcess.Id ) return ApplicationState.Focused;
                    if(wordProcess.MainWindowHandle == activeWindowHandle)
                    {
                        return ApplicationState.Focused;
                    }
                }
                return ApplicationState.Running;
            }
            return ApplicationState.NotRunning;
        }
    } 
