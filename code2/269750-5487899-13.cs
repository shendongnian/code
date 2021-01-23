    private static MyData ReadDataFile(string path)
    {
        UnauthorizedAccessException exception = null;
        for (int attemptCount = 0; attemptCount < maxRetryAttempts; attemptCount++)
        {
            try
            {
                return ReadDataFileCore(path);
            }
            catch(UnauthorizedAccessException ex)
            {
                 exception = ex;
                 MessageBox.Show(ex.Message);
            }
        }
        throw exception;  // The StackTrace gets replaced to indicate this line of code.
    }
