        static void Main(string[] args)
        {
            CalculateSize("C:\\", 1000,
                result => Console.WriteLine("Finished: {0} bytes", result),
                (result, ex) => Console.WriteLine("Incomplete results: {0} bytes - {1}", result, ex.Message));
            Console.ReadLine();
        }
        public static void CalculateSize(string directory, int timeout, Action<long> onSuccess, Action<long, Exception> onFailure)
        {
            // Create an invoke a delegate on a separate thread.
            var del = new Action<string, int, Action<long>, Action<long, Exception>>(CalculateSizeImpl);
            del.BeginInvoke(directory, timeout, onSuccess, onFailure, iar =>
                {
                    try
                    {
                        del.EndInvoke(iar);
                    }
                    catch (Exception ex)
                    {
                        onFailure(0, ex);
                    }
                }, null);
        }
        static void CalculateSizeImpl(string directory, int timeout, Action<long> onSuccess, Action<long, Exception> onFailure)
        {
            var completeBy = Environment.TickCount + timeout;
            var size = 0L;
            var visited = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            try
            {
                CalculateSizeRecursive(directory, completeBy, ref size, visited);
            }
            catch (Exception ex)
            {
                // Call the failure callback, but give the
                // value before the timeout to it.
                onFailure(size, ex);
                return;
            }
            // Just return the value.
            onSuccess(size);
        }
        static void CalculateSizeRecursive(string directory, int completeBy, ref long size, HashSet<string> visited)
        {
            foreach (var file in Directory.GetFiles(directory, "*"))
            {
                if (Environment.TickCount > completeBy)
                    throw new TimeoutException();
                size += new FileInfo(file).Length;
            }
            // Cannot use SearchOption.All, because you won't get incomplete results -
            // only ever 0 or the actual value.
            foreach (var dir in Directory.GetDirectories(directory, "*"))
            {
                if (Environment.TickCount > completeBy)
                    throw new TimeoutException();
                if (visited.Add(dir))
                    CalculateSizeRecursive(dir, completeBy, ref size, visited);
            }
        }
