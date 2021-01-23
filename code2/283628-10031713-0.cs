        private string ObtainProcessName()
        {
            string baseProcessName;
            string processName = null;
            int processId;
            bool notFound = true;
            int processOptionsChecked = 0;
            int maxNrOfParallelProcesses = 3 + 1;
            try
            {
                baseProcessName = Process.GetCurrentProcess().ProcessName;
            }
            catch (Exception exception)
            {
                return null;
            }
            try
            {
                processId = Process.GetCurrentProcess().Id;
            }
            catch (Exception exception)
            {
                return null;
            }
            while (notFound)
            {
                processName = baseProcessName;
                if (processOptionsChecked > maxNrOfParallelProcesses)
                {
                    break;
                }
                if (1 == processOptionsChecked)
                {
                    processName = string.Format("{0}_{1}", baseProcessName, processId);
                }
                else if (processOptionsChecked > 1)
                {
                    processName = string.Format("{0}#{1}", baseProcessName, processOptionsChecked - 1);
                }
                try
                {
                    PerformanceCounter counter = new PerformanceCounter("Process", "ID Process", processName);
                    if (processId == (int)counter.NextValue())
                    {
                        notFound = !true;
                    }
                }
                catch (Exception)
                {
                }
                processOptionsChecked++;
            }
            return processName;
        }
