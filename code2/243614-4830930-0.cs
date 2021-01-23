    private void closeSubProcess()
        {
            Process[] currentProcesses = Process.GetProcesses();
            foreach (Process p in currentProcesses)
            {
                string s = p.ProcessName;
                s = s.ToLower();
                if (s.CompareTo("YOURPROGRAMNAMEHERE") == 0)
                {
                    p.CloseMainWindow();
                    p.Close();
                }
            }
        }
