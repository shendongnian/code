        private static long SizeOf(string directory)
        {
            var fcounter = new CSharpTest.Net.IO.FindFile(directory, "*", true, true, true);
            fcounter.RaiseOnAccessDenied = false;
            long size = 0, total = 0;
            fcounter.FileFound +=
                (o, e) =>
                {
                    if (!e.IsDirectory)
                    {
                        Interlocked.Increment(ref total);
                        size += e.Length;
                    }
                };
            Stopwatch sw = Stopwatch.StartNew();
            fcounter.Find();
            Console.WriteLine("Enumerated {0:n0} files totaling {1:n0} bytes in {2:n3} seconds.",
                              total, size, sw.Elapsed.TotalSeconds);
            return size;
        }
