    foreach (var fileInfo in jsFiles)
    {
        using (Process process = new Process())
        {
            try
            {
                //Other stuff
                process.Start();
            }
            catch (...)
            {
                //Exception Handling goes here...
            }
            finally
            {
                try
                {
                    process.WaitForExit();
                }
                catch (...)
                {
                }
            }
        }
    }
