      public static async Task<bool> CancellationExpectedAsync(this Task task)
        {
            using (var ss = new SemaphoreSlim(1, 1))
            {
                if (task.Status != TaskStatus.Canceled && task.Status != TaskStatus.Faulted && task.Status != TaskStatus.RanToCompletion)
                {
                    await ss.WaitAsync();
                    task.ContinueWith(_ => ss.Release());
                }
                await ss.WaitAsync();
                return task.IsCanceled;
            }
        }
