    Device.StartTimer(TimeSpan.FromSeconds(1), () => {
    if (cts.IsCancellationRequested)
    {
        return false;
    }
    else {
        Device.BeginInvokeOnMainThread(() => {
            TimeSpan _TimeSpan += TimeSpan.FromMinutes(myItem.TotalTime);
            displaytime = _TimeSpan.ToString(@"hh\:mm\:ss");
            Console.WriteLine("Timer");
            Console.WriteLine(displaytime);
        });
        return true;
    }
});
