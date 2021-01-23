           Process[] pArry = Process.GetProcesses();
           foreach (Process p in pArry)
           {
               if (p.Id == Process.GetCurrentProcess().Id)
                    continue;
               string ProcessName = p.ProcessName;
               if(ProcessName == Process.GetCurrentProcess().ProcessName)
               {
                    MessageBox.Show(AppAlreadyRunning,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error)
                    SetForegroundWindow(p.MainWindowHandle);
                    Application.Exit();
               }
           }   
