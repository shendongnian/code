    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    
    class ThreadAffineList<T> : IList<T>
    {
        private readonly Thread expectedThread;
        private readonly IList<T> list;
        
        public ThreadAffineList(IList<T> list)
        {
            this.list = list;
            this.expectedThread = Thread.CurrentThread;
        }
        
        private void CheckThread()
        {
            if (Thread.CurrentThread != expectedThread)
            {
                throw new InvalidOperationException("Incorrect thread");
            }
        }
            
        // Modification methods: delegate after checking thread
        public T this[int index]
        {
            get { return list[index]; }
            set
            {
                CheckThread();
                list[index] = value;
            }
        }
        
        public void Add(T item)
        {
            CheckThread();
            list.Add(item);
        }
        
        public void Clear()
        {
            CheckThread();
            list.Clear();
        }
        
        public void Insert(int index, T item)
        {
            CheckThread();
            list.Insert(index, item);
        }
        
        public bool Remove(T item)
        {
            CheckThread();
            return list.Remove(item);
        }
        
        public void RemoveAt(int index)
        {
            CheckThread();
            list.RemoveAt(index);
        }
            
        // Read-only members
        public int Count { get { return list.Count; } }
        public bool IsReadOnly { get { return list.IsReadOnly; } }
        
        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        public bool Contains(T item)
        {
            return list.Contains(item);
        }
        
        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }
        
        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }
    }
