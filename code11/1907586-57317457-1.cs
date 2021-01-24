    class Trend<T>
        {
            private CancellationTokenSource cancellationToken = new CancellationTokenSource();
        public void AddObservation(T observation)
        {
            // I don't really care about T.
            //
            Func<CancellationToken, T, Task> action = async (CancellationToken token, T obs) =>
            {
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(5), token);
                    if (!token.IsCancellationRequested)
                    {
                        Console.WriteLine($"{DateTime.UtcNow} Task executed {obs}");
                    }
                }
                catch (TaskCanceledException)
                {
                }
            };
    
            // cancel previos execution, if any.
            cancellationToken.Cancel();
    
            // create new token
            cancellationToken = new CancellationTokenSource();
    
            action(cancellationToken.Token, observation);
        }
    }
