public class AwaitableQueue<T>
{
    private SemaphoreSlim semaphore = new SemaphoreSlim(0);
    private readonly object queueLock = new object();
    private Queue<T> queue = new Queue<T>();
    public void Enqueue(T item)
    {
        lock (queueLock)
        {
            queue.Enqueue(item);
            semaphore.Release();
        }
    }
    public T WaitAndDequeue(TimeSpan timeSpan, CancellationToken cancellationToken)
    {
        semaphore.Wait(timeSpan, cancellationToken);
        lock (queueLock)
        {
            return queue.Dequeue();
        }
    }
    public async Task<T> WhenDequeue()
    {
        await semaphore.WaitAsync(TimeSpan timeSpan, CancellationToken cancellationToken);
        lock (queueLock)
        {
            return queue.Dequeue();
        }
    }
}
The beauty of this is that the `SemaphoreSlim` handles all of the complexity of implementing the `Wait()` and `WaitAsync()` functionality. The downside is that queue length is tracked by both the semaphore *and* the queue itself, and they both magically stay in sync.
