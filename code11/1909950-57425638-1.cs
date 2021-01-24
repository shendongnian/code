    public async void GetVehiclePositionRepeatAsync(TimeSpan interval, CancellationToken cancellationToken)
    {
            while (!cancellationToken.IsCancellationRequested) { 
                var task = new Task(() =>
                {
                    cancellationToken.Token.ThrowIfCancellationRequested();
                    var not = new PushNotificationGenerator(this, "Hooray!", "yay", "STOP_NOTIFICATIONS");
                    not.Push();
                },cancellationToken.Token);
                task.Start();
                await Task.Delay(interval);
            }
        }
    }
