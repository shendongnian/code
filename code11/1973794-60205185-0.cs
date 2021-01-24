     protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                int hourSpan = 23 - DateTime.Now.Hour;
                var numberOfHours = hourSpan == 0 ? hourSpan : 23;
                //do something
                await Task.Delay(TimeSpan.FromHours(numberOfHours), stoppingToken);
            }
            while (!stoppingToken.IsCancellationRequested);
        }
