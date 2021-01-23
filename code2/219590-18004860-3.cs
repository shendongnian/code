    private void WaitForCreatingProcessToCloseFileThenDoStuff(object threadContext)
    {
        // Make sure the just-found file is done being
        // written by repeatedly attempting to open it
        // for exclusive access.
        var path = (string)threadContext;
        DateTime started = DateTime.Now;
        DateTime lastLengthChange = DateTime.Now;
        long lastLength = 0;
        var noGrowthLimit = new TimeSpan(0, 5, 0);
        var notFoundLimit = new TimeSpan(0, 0, 1);
        for (int tries = 0;; ++tries)
        {
            try
            {
                using (var fileStream = new FileStream(
                   path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    // Do Stuff
                }
                break;
            }
            catch (FileNotFoundException)
            {
                // Sometimes the file appears before it is there.
                if (DateTime.Now - started > notFoundLimit)
                {
                    // Should be there by now
                    break;
                }
            }
            catch (IOException ex)
            {
                // mask in severity, customer, and code
                var hr = (int)(ex.HResult & 0xA000FFFF);
                if (hr != 0x80000020 && hr != 0x80000021)
                {
                    // not a share violation or a lock violation
                    throw;
                }
            }
            try
            {
                var fi = new FileInfo(path);
                if (fi.Length > lastLength)
                {
                    lastLength = fi.Length;
                    lastLengthChange = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
            }
            // still locked
            if (DateTime.Now - lastLengthChange > noGrowthLimit)
            {
                // 5 minutes, still locked, no growth.
                break;
            }
            Thread.Sleep(111);
        }
