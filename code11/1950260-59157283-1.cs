c#
public class MyQueue<T>
{
    private Queue<T> _queue = new Queue<T>();
    private T[] last10items = new T[10];
    private int itemsEnqueued = 0;
    public void Enqueue(T item)
    {
        _queue.Enqueue(item);
        last10items[itemsEnqueued++%10] = item; // store your last 10 items in an array
        // notify
    }
    public T Dequeue()
    {
        return _queue.Dequeue();
        // notify
    }
    public T[] Last10Items()
    {
        // clone your array if you want to read it. Don't use your queue, because it will change while reading
        return last10items.Clone() as T[]; 
    }
}
For a threadsafe-version have a look at:
[ConcurrentQueue<T>][1]
Example-call to the new queue:
c#
static void Main(string[] args)
{
    MyQueue<int> myQueue = new MyQueue<int>();
    var task1 = Task.Run(()=>
    Parallel.For(0, 10000,
        (x) =>
        {
            myQueue.Enqueue(x);
            Console.WriteLine(x + ": " + string.Join(", ", myQueue.Last10Items()));
        }));
    
    Thread.Sleep(1000);
    var task2 = Task.Run(() =>
        Parallel.For(0, 10000,
            (x) =>
            {
                int y = myQueue.Dequeue();
                Console.WriteLine(y + ": " + string.Join(", ", myQueue.Last10Items()));
            }));
    task1.Wait();
    task2.Wait();
}
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentqueue-1?view=netframework-4.8
