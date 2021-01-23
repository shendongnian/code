        public static List<System.Diagnostics.PerformanceCounter> GetPerformanceCounters()
        {
            List<System.Diagnostics.PerformanceCounter> performanceCounters = new List<System.Diagnostics.PerformanceCounter>();
            int procCount = System.Environment.ProcessorCount;
            for (int i = 0; i < procCount; i++)
            {
                System.Diagnostics.PerformanceCounter pc = new System.Diagnostics.PerformanceCounter("Processor", "% Processor Time", i.ToString());
                performanceCounters.Add(pc);
            }
            return performanceCounters;
        }
