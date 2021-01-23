    private void WaitForCreatingProcessToCloseFileThenDoStuff(object threadContext)
    {
        // Make sure the just-found file is done being
        // written by repeatedly attempting to open it
        // for exclusive access.
        var path = (string)threadContext;
        for (int tries = 0;; ++tries)
        {
            try
            {
                using (var fileStream = new FileStream(
                    path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    // DoStuff
                }
                break;
            }
            catch (FileNotFoundException)
            {
                // ignore, sometimes the file appears before it is there.
                if (tries > 9)
                {
                    // about a second
                    this.Log("Lost {0}, skipping it", path);
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
            // still locked
            if (tries == 1350)
            {
                // about 5 minutes
                this.Log("Failed to open {0}, skipping it", path);
                break;
            }
            Thread.Sleep(111);
        }
