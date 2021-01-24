    public Task StartAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var currentTime = DateTime.UtcNow;
                //run background task at 11:00:00
                if(currentTime.Hour == 11 && currentTime.Minute == 0 && currentTime.Second == 0)
                {
                    _logger.LogInformation(currentTime.ToString());
                    DoWork();
                }              
            }
            
            return Task.CompletedTask;
        }
