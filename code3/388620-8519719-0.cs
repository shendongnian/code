    System.Diagnostics.Process[] IEProcesses = System.Diagnostics.Process.GetProcessesByName("iexplore.exe");
            foreach (System.Diagnostics.Process CurrentProcess in IEProcesses)
            {
                if (CurrentProcess.MainWindowTitle.ToUpper().Contains("MSN | USA - Hotmail, Messenger"))
                {
                    CurrentProcess.Kill();
                }
            }
