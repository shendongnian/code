    public static async Task<bool> TryWithTimeoutAfter<TResult>(this Task<TResult> task,
        TimeSpan timeout, Action<TResult> successor)
    {
        using var timeoutCancellationTokenSource = new CancellationTokenSource();
        var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token))
                                      .ConfigureAwait(continueOnCapturedContext: false);
            if (completedTask == task)
            {
                timeoutCancellationTokenSource.Cancel();
                // propagate exception rather than AggregateException, if calling task.Result.
                var result = await task.ConfigureAwait(continueOnCapturedContext: false);
                successor(result);
                return true;
            }
            else return false;
        }
    }     
    async Task Example(Task<string> task)
    {
        string result = null;
        if (await task.TryWithTimeoutAfter(TimeSpan.FromSeconds(1), r => result = r))
        {
            Console.WriteLine(result);
        }
    }    
