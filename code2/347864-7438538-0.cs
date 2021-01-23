    CancellationTokenSource cancel = new CancellationTokenSource();
    Task.Factory
          .StartNew(() => PollHardware(cancel.Token), TaskCreationOptions.LongRunning)
          .ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    var aggException = t.Exception; // Keep task from pulling down AppDomain
                    // Log/handle/etc
                    LogException(aggException.InnerException);
                }
            });
