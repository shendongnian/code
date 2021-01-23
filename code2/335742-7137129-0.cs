    public class HiResTimer
    {
        private bool isPerfCounterSupported = false;
        private Int64 frequency = 0;
    
        // Windows CE native library with QueryPerformanceCounter().
        private const string lib = "coredll.dll";
        [DllImport(lib)]
        private static extern int QueryPerformanceCounter(ref Int64 count);
        [DllImport(lib)]
        private static extern int QueryPerformanceFrequency(ref Int64 frequency);
    
        public HiResTimer()
        {
            // Query the high-resolution timer only if it is supported.
            // A returned frequency of 1000 typically indicates that it is not
            // supported and is emulated by the OS using the same value that is
            // returned by Environment.TickCount.
            // A return value of 0 indicates that the performance counter is
            // not supported.
            int returnVal = QueryPerformanceFrequency(ref frequency);
    
            if (returnVal != 0 && frequency != 1000)
            {
                // The performance counter is supported.
                isPerfCounterSupported = true;
            }
            else
            {
                // The performance counter is not supported. Use
                // Environment.TickCount instead.
                frequency = 1000;
            }
        }
    
        public Int64 Frequency
        {
            get
            {
                return frequency;
            }
        }
    
        public Int64 Value
        {
            get
            {
                Int64 tickCount = 0;
    
                if (isPerfCounterSupported)
                {
                    // Get the value here if the counter is supported.
                    QueryPerformanceCounter(ref tickCount);
                    return tickCount;
                }
                else
                {
                    // Otherwise, use Environment.TickCount.
                    return (Int64)Environment.TickCount;
                }
            }
        }
    
        static void Main()
        {
            HiResTimer timer = new HiResTimer();
    
            // This example shows how to use the high-resolution counter to 
            // time an operation. 
    
            // Get counter value before the operation starts.
            Int64 counterAtStart = timer.Value;
    
            // Perform an operation that takes a measureable amount of time.
            for (int count = 0; count < 10000; count++)
            {
                count++;
                count--;
            }
    
            // Get counter value when the operation ends.
            Int64 counterAtEnd = timer.Value;
    
            // Get time elapsed in tenths of a millisecond.
            Int64 timeElapsedInTicks = counterAtEnd - counterAtStart;
            Int64 timeElapseInTenthsOfMilliseconds =
                (timeElapsedInTicks * 10000) / timer.Frequency;
    
            MessageBox.Show("Time Spent in operation (tenths of ms) "
                           + timeElapseInTenthsOfMilliseconds +
                           "\nCounter Value At Start: " + counterAtStart +
                           "\nCounter Value At End : " + counterAtEnd +
                           "\nCounter Frequency : " + timer.Frequency);
        }
    }
