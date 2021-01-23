    public class MessageQueue<T>
    {
        ConcurrentQueue<T> queue = new ConcurrentQueue<T>();
        ConcurrentQueue<TaskCompletionSource<T>> waitingQueue = 
            new ConcurrentQueue<TaskCompletionSource<T>>();
        object queueSyncLock = new object();
        public void Enqueue(T item)
        {
            queue.Enqueue(item);
            ProcessQueues();
        }
        public async Task<T> DequeueAsync(CancellationToken ct)
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            ct.Register(() =>
            {
                lock (queueSyncLock)
                {
                    tcs.TrySetCanceled();
                }
            });
            waitingQueue.Enqueue(tcs);
            ProcessQueues();
            return tcs.Task.IsCompleted ? tcs.Task.Result : await tcs.Task;
        }
        private void ProcessQueues()
        {
            TaskCompletionSource<T> tcs = null;
            T firstItem = default(T);
            lock (queueSyncLock)
            {
                while (true)
                {
                    if (waitingQueue.TryPeek(out tcs) && queue.TryPeek(out firstItem))
                    {
                        waitingQueue.TryDequeue(out tcs);
                        if (tcs.Task.IsCanceled)
                        {
                            continue;
                        }
                        queue.TryDequeue(out firstItem);
                    }
                    else
                    {
                        break;
                    }
                    tcs.SetResult(firstItem);
                }
            }
        }
    }
