    Task.Factory.StartNew(() => LongerOperation())
    .ContinueWith(t =>
        {
            textBox.Text=String.Format("The result is {0}",t.Result);
        },
        CancellationToken.None,
        TaskContinuationOptions.NotOnFaulted,
        TaskScheduler.FromCurrentSynchronizationContext());
