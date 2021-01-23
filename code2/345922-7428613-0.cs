    System.Diagnostics.Process process = Process.GetProcessesByName("OpenSim.32BitLaunch")[0];
                 
            Process[] processes = Process.GetProcessesByName("OpenSim.32BitLaunch");
            
            foreach (Process p in processes)
              {
                
                  SetForegroundWindow(p.MainWindowHandle);
                  Thread.Sleep(1000);
                  SendKeys.SendWait("quit");
                  Thread.Sleep(1000);
                  SendKeys.SendWait("{ENTER}");
                           
              }
