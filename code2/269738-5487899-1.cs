    private const int maxRetryAttempts = 3;
    
    private static MyData ReadDataFile(string path)
    {
        int remainingAttempts = maxRetryAttempts;
        while (true)
        {
            try
            {
                return ReadDataFileCore(path);
            }
            catch(UnauthorizedAccessException ex)
            {
                 if (remainingAttemtps <= 0)
                     throw;
                 remainingAttempts--;             
                 MessageBox.Show(ex.Message);
            }
        }
    }
