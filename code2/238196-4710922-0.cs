        public static string GetInstanceNameForProcessId(int pid)
        {
            var cat = new PerformanceCounterCategory(".NET CLR Memory");
            foreach (var instanceName in cat.GetInstanceNames())
            {
                using (var pcPid = new PerformanceCounter(cat.CategoryName, "Process ID", instanceName))
                {
                    if ((int)pcPid.NextValue() == pid)
                    {
                        return instanceName;
                    }
                }
            }
            throw new ArgumentException(
                string.Format("No performance counter instance found for process id '{0}'", pid),
                "pid");
        }
