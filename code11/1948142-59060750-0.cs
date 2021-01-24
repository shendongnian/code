    No easy way i guess.This is not a clear way, but hopefully you can work with it
 
    Process[] procs = Process.GetProcessesByName("Internet");
    
                if (procs.Length == 0)
                {
                    Console.WriteLine("internet is not currently open");
    
                }
    
                List<string> titles = new List<string>();
    
                IntPtr hWnd = IntPtr.Zero;
                int id = 0;
                int numTabs = procs.Length;
    
                foreach (Process p in procs)
                {
                    if (p.MainWindowTitle.Length > 0)
                    {
                        hWnd = p.MainWindowHandle;
                        id = p.Id;
                        break;
                    }
                }
    
                bool isMinimized = IsIconic(hWnd);
    
                if (isMinimized)
                {
                    ShowWindow(hWnd, 9); // restore
                    Thread.Sleep(100);
                }
    
                SetForegroundWindow(hWnd);
                SendKeys.SendWait("^+1"); // change focus to first tab
