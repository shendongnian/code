      public static async Task<bool> CancellationExpectedAsync(this Task task)
        {
            using (var ss = new SemaphoreSlim(0, 1))
            {
                var syncTask = ss.WaitAsync();
                task.ContinueWith(_ => ss.Release());
                await syncTask;
                return task.IsCanceled;
            }
        }
