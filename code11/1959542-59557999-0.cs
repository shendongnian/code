     CancellationTokenSource cts;
        private async void Start_Clicked(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            try
            {
                // ***Send a token to carry the message if cancellation is requested.
                await task1(cts.Token);
            }
            // *** If cancellation is requested, an OperationCanceledException results.
            catch (OperationCanceledException)
            {
                Console.WriteLine("the request is canceled!");
            }
            cts = null;
        }
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
        }
        Task task1(CancellationToken ct)
        {
            TaskCompletionSource<DateTime> tcs = new TaskCompletionSource<DateTime>();
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("the valuie is {0}", i);
                    if (ct.IsCancellationRequested == true)
                    {
                        Console.WriteLine("request cancel!");
                        tcs.SetCanceled();
                        break;
                    }
                }
            }, ct);
            return tcs.Task;
        }
