      public static async Task<bool> CancellationExpectedAsync(this Task task)
        {
            using (var ss = new SemaphoreSlim(0, 1))
            {
                task.ContinueWith(_ => ss.Release());
                await ss.WaitAsync();
                return task.IsCanceled;
            }
        }
