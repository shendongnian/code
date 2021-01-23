    static class ThreadingExtensions
    {
        // Possible:
        // [ThreadStatic]
        // private static List<WaitHandle> PerThreadWaitList;
        public const int MaxHandlesPerWait = 64;
        public static void WaitAll<T>(this IEnumerable<T> handles, int millisecondsTimeout, int estimatedCount)
            where T : WaitHandle
        {
            // Possible:
            // var currentSet = PerThreadWaitList ?? (PerThreadWaitList = new List<WaitHandle>(estimatedCount));
            var currentSet = new List<WaitHandle>(Math.Min(estimatedCount, MaxHandlesPerWait));
            var timeoutEnd = Environment.TickCount + millisecondsTimeout;
            int timeout;
            // Wait for items in groups of 64.
            foreach (var item in handles)
            {
                currentSet.Add(item);
                if (currentSet.Count == MaxHandlesPerWait)
                {
                    timeout = Timeout.Infinite;
                    if (millisecondsTimeout >= 0)
                    {
                        timeout = timeoutEnd - Environment.TickCount;
                        if (timeout < 0)
                            throw new TimeoutException();
                    }
                    WaitHandle.WaitAll(currentSet.ToArray(), timeout);
                    currentSet.Clear();
                }
            }
            // Do the last set.
            if (currentSet.Count > 0)
            {
                timeout = Timeout.Infinite;
                if (millisecondsTimeout >= 0)
                {
                    timeout = timeoutEnd - Environment.TickCount;
                    if (timeout < 0)
                        timeout = 0;
                }
                WaitHandle.WaitAll(currentSet.ToArray(), timeout);
                currentSet.Clear();
            }
        }
    }
