        public static IList Processes()
        {
            IList<Process> processes = new List<Process>();
            foreach (System.Diagnostics.Process process in System.Diagnostics.Process.GetProcesses())
            {
                Process p = new Process();
                p.Pid = process.Id;
                p.Name = process.ProcessName;
                processes.Add(p);
            }
            return processes;
        }
