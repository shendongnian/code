           Process[] pArry = Process.GetProcesses();
           int nCount = 0;
           foreach (Process p in pArry)
           {
               string ProcessName = p.ProcessName;
               if(ProcessName == Process.GetCurrentProcess().ProcessName)
                    Application.Exit();
           }   
           if (nCount > 1)
           {
               MessageBox.Show(AppAlreadyRunning,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
               Process.GetCurrentProcess().Kill();
           }
