    private readonly AsyncLock _lock = new AsyncLock();
    private async void Save()
    {
        var id = Guid.NewGuid();
        
        using (await _lock.LockAsync())
            {
                // It's safe to await while the lock is held
                Debug.WriteLine($"Starting save {id}");
                await Task.Delay(100);  // Simulate slow task
                
                Debug.WriteLine($"Finished save {id}");
            }
    }
