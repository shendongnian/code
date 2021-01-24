    /// <summary>
    ///     Implementation borrowed from [How to: Create an Object Pool by Using a
    ///     ConcurrentBag](https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/how-to-create-an-object-pool).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> : IDisposable
        where T : IDisposable
    {
        private readonly Func<T> _objectGenerator;
        private readonly ConcurrentBag<T> _objects;
    
        public ObjectPool(Func<T> objectGenerator)
        {
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
            _objects = new ConcurrentBag<T>();
        }
    
        public void Dispose()
        {
            while (_objects.TryTake(out var item))
            {
                item.Dispose();
            }
        }
    
        public T GetObject()
        {
            return _objects.TryTake(out var item) ? item : _objectGenerator();
        }
    
        public void PutObject(T item)
        {
            _objects.Add(item);
        }
    }
