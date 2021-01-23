    Task.Factory.StartNew(() =>
                {
                    // Background work
                }).ContinueWith((t) => {
                    // Update UI thread
    
                }, TaskScheduler.FromCurrentSynchronizationContext());
