    public void LogProcessor()
        {
           if (_isRunning)
            {
                WriteNewLogsToDisk();              
                // Come back in 2 seonds
                var t = Task.Run(async delegate
                {
                    await Task.Delay(2000);
                    LogProcessor();
                });               
            }
        }
