        /// <summary>
        /// Gets the process memory.
        /// </summary>
        /// <param name="processId">The process identifier.</param>
        /// <returns></returns>
        /// <para> </para>
        /// <para> </para>
        /// <exception cref="ArgumentException"> </exception>
        /// <exception cref="ArgumentNullException"> </exception>
        /// <exception cref="ComponentModel.Win32Exception"> </exception>
        /// <exception cref="InvalidOperationException"> </exception>
        /// <exception cref="PlatformNotSupportedException"> </exception>
        /// <exception cref="UnauthorizedAccessException"> </exception>
        public static long GetProcessMemory(int processId)
        {
            try
            {
                var instanceName = Process.GetProcessById(processId).ProcessName;
                using (var performanceCounter = new PerformanceCounter("Process", "Working Set - Private", instanceName))
                {
                    return performanceCounter.RawValue / Convert.ToInt64(1024);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
