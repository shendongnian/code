     static bool LogError(string filename, string log)
        {
            const int MAX_RETRY = 10;
            const int DELAY_MS = 1000; // 1 second
            bool result = false;
            int retry = 0;
            bool keepRetry = true;
            while (keepRetry && !result && retry < MAX_RETRY )
            {
                try
                {
                    using (StreamWriter file = new StreamWriter(filename, true))
                    {
                        // write the line
                        file.WriteLine(log);
                        // success
                        result = true;
                    }
                }
                catch (IOException ioException)
                {
                    Thread.Sleep(DELAY_MS);
                    retry++; 
                }
                catch (Exception e)
                {
                    keepRetry = false;
                }
                
            }
            return result;
        }
