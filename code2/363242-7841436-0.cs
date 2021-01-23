    using System;
    using System.Collections.Generic;
    using System.Threading;
    namespace MyCollections
    {
    public class BlockingQueue<T> : IDisposable
    {
        Queue<T> _Queue = new Queue<T>();
        SemaphoreSlim _ItemsInQueue = null;
        SemaphoreSlim _FreeSlots = null;
        int _MaxItems = -1;
        public BlockingQueue(int maxItems=Int32.MaxValue)
        {
            _MaxItems = maxItems;
            _ItemsInQueue = new SemaphoreSlim(0, maxItems);
            _FreeSlots = new SemaphoreSlim(maxItems, maxItems);
        }
        public void Dispose()
        {
            if (_ItemsInQueue != null) _ItemsInQueue.Dispose();
            if (_FreeSlots != null) _FreeSlots.Dispose();
        }
        public int Count
        {
            get { return _ItemsInQueue.CurrentCount; }
        }
        public void Add(T item)
        {
            if(_MaxItems != Int32.MaxValue) _FreeSlots.Wait();
            lock (this)
            {
                _Queue.Enqueue(item);
                _ItemsInQueue.Release();
            }
        }
        public T Take()
        {
            T item = default(T);
            _ItemsInQueue.Wait();
            lock (this)
            {
                 item = _Queue.Dequeue();
                 if (_MaxItems != Int32.MaxValue)  _FreeSlots.Release();
            }
            return item;
        }
    }
    }
