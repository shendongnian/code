    private string _username;
    public string Username
    {
        get => _username;
        set
        {
            SetProperty(ref _username, value);
            CheckUsernameExistsAsync(value, 1000);
        }
    }
    private CancellationTokenSource _cts;
    private async void CheckUsernameExistsAsync(string username, int timeout)
    {
        try
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            var cancellationToken = _cts.Token;
            await Task.Delay(timeout, cancellationToken);
            // Check if the username exists
            // Use the same cancellationToken if the API supports it
        }
        catch (TaskCanceledException)
        {
            // Ignore the exception
        }
        catch (Exception)
        {
            // Log the exception
        }
    }
