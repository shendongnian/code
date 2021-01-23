    private static void ReadDataFile(string path)
    {
        for (int attemptCount = 0; attemptCount < maxRetryAttempts; attemptCount++)
        {
            try
            {
                ReadDataFileCore(path);
            }
            catch(UnauthorizedAccessException ex)
            {
                 MessageBox.Show(ex.Message);
            }
        }
        //  Compiles justs fine, but did we actually read the data file? 
    }
