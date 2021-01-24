    CancellationTokenSource cts = _cancellationTokenSource; // safe copy
    this._startedAt = DateTime.Now;
    Device.StartTimer(TimeSpan.FromSeconds(1),() =>
    {
        if (cts.IsCancellationRequested)
        {
            return false;
        }
        else
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                TimeSpan _TimeSpan = DateTime.Now - _startedAt;
                LblTime = _TimeSpan.ToString("hh:mm:ss);
                IsVisibleTimerLabel = true;
                Count();
            });
            return true;
        }
    });
