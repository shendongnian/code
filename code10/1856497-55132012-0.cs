    private readonly AsyncLock _lock = new AsyncLock();
    private async void Save()
    {
        var id = Guid.NewGuid();
        Debug.WriteLine($"Starting save {id}");
        using (await _lock.LockAsync())
            {
                // It's safe to await while the lock is held
                await Task.Delay(100);  // Simulate slow task
            }
        Debug.WriteLine($"Finished save {id}");
    }
