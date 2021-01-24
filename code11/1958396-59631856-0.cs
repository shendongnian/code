    Process[] ProcessList = Process.GetProcesses();
                foreach (Process process in ProcessList)
                {
                    if (process.MainWindowTitle == "Session C")
                    {
                        try
                        {
                            IntPtr hWnd = IntPtr.Zero;
                            hWnd = process.MainWindowHandle;
                            SetForegroundWindow(process.MainWindowHandle);
                        } catch (Exception ex)
                        {
                            
                            Debug.WriteLine("no proc found" + ex.Message);
                        }
                    }
    
                }
