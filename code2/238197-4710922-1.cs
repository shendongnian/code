        public static string GetInstanceNameForProcessId(int pid)
        {
            var cat = new PerformanceCounterCategory(".NET CLR Memory");
            foreach (var instanceName in cat.GetInstanceNames())
            {
                try
                {
                     using (var pcPid = new PerformanceCounter(cat.CategoryName, "Process ID", instanceName))
                     {
                         if ((int)pcPid.NextValue() == pid)
                         {
                             return instanceName;
                         }
                     }
                }
                catch (InvalidOperationException)
                {
                    // This may happen, if the PC-instance no longer exists between the
                    // time we called GetInstanceNames() and the time we come around actually
                    // try and use the instance. 
                    // In this situation that is not an error, so ignore it.
                }
            }
            throw new ArgumentException(
                string.Format("No performance counter instance found for process id '{0}'", pid),
                "pid");
        }
