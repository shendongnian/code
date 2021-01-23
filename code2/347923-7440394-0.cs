    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    
    namespace ConsoleApplication
    {
        internal class Program
        {
            [Serializable]
            private class HashQueue<T> : ISerializable, IDeserializationCallback, ISet<T>, ICollection<T>, IEnumerable<T>, IEnumerable
            {
                private int _maxCount;
                private Queue<T> _queue = new Queue<T>();
                private HashSet<T> _set = new HashSet<T>();
    
                public HashQueue(int maxCount = 0)
                {
                    if (maxCount < 0) throw new ArgumentOutOfRangeException("maxCount");
                    _maxCount = maxCount;
                }
    
                public bool Add(T item)
                {
                    lock (this)
                    {
                        if (_queue.Count == _maxCount)
                        {
                            _set.Remove(_queue.Dequeue());
                        }
                        if (_set.Add(item))
                        {
                            _queue.Enqueue(item);
                            return true;
                        }
                        return false;
                    }
                }
    
                public bool Remove(T item)
                {
                    lock (this)
                    {
                        if (object.ReferenceEquals(_queue.Peek(), item))
                        {
                            return _set.Remove(_queue.Dequeue());
                        }
                        return false;
                    }
                }
    
                public void Clear()
                {
                    lock (this)
                    {
                        _set.Clear();
                        _queue.Clear();
                    }
                }
    
                public bool Contains(T item)
                {
                    lock (this)
                    {
                        return _set.Contains(item);
                    }
                }
    
                public void CopyTo(T[] array, int arrayIndex)
                {
                    lock (this)
                    {
                        _queue.CopyTo(array, arrayIndex);
                    }
                }
    
                public int Count
                {
                    get
                    {
                        lock (this)
                        {
                            return _queue.Count;
                        }
                    }
                }
    
                public bool IsReadOnly
                {
                    get
                    {
                        return false;
                    }
                }
    
                public void ProcessItems(Action<T> action)
                {
                    lock (this)
                    {
                        foreach (T item in _queue)
                        {
                            action(item);
                        }
                    }
                }
    
                void ICollection<T>.Add(T item)
                {
                    lock (this)
                    {
                        if (_queue.Count == _maxCount - 1)
                        {
                            _set.Remove(_queue.Dequeue());
                        }
                        if (!_set.Add(item))
                        {
                            throw new ArgumentOutOfRangeException("item");
                        }
                        _queue.Enqueue(item);
                    }
                }
    
                public IEnumerator<T> GetEnumerator()
                {
                    lock (this)
                    {
                        return _queue.GetEnumerator();
                    }
                }
    
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    lock (this)
                    {
                        return (IEnumerator)GetEnumerator();
                    }
                }
    
                public void OnDeserialization(object sender)
                {
                    lock (this)
                    {
                        _set.OnDeserialization(sender);
                    }
                }
    
                private void RebuildQuery()
                {
                    _queue.Clear();
                    foreach (T item in _set)
                    {
                        _queue.Enqueue(item);
                    }
                }
    
                public void ExceptWith(IEnumerable<T> other)
                {
                    lock (this)
                    {
                        _set.ExceptWith(other);
                        RebuildQuery();
                    }
                }
    
                public void IntersectWith(IEnumerable<T> other)
                {
                    lock (this)
                    {
                        _set.IntersectWith(other);
                        RebuildQuery();
                    }
                }
    
                public bool IsProperSubsetOf(IEnumerable<T> other)
                {
                    lock (this)
                    {
                        return _set.IsProperSubsetOf(other);
                    }
                }
    
                public bool IsProperSupersetOf(IEnumerable<T> other)
                {
                    lock (this)
                    {
                        return _set.IsProperSupersetOf(other);
                    }
                }
    
                public bool IsSubsetOf(IEnumerable<T> other)
                {
                    lock (this)
                    {
                        return _set.IsSubsetOf(other);
                    }
                }
    
                public bool IsSupersetOf(IEnumerable<T> other)
                {
                    lock (this)
                    {
                        return _set.IsSupersetOf(other);
                    }
                }
    
                public bool Overlaps(IEnumerable<T> other)
                {
                    lock (this)
                    {
                        return _set.Overlaps(other);
                    }
                }
    
                public bool SetEquals(IEnumerable<T> other)
                {
                    lock (this)
                    {
                        return _set.SetEquals(other);
                    }
                }
    
                public void SymmetricExceptWith(IEnumerable<T> other)
                {
                    lock (this)
                    {
                        _set.SymmetricExceptWith(other);
                        RebuildQuery();
                    }
                }
    
                public void UnionWith(IEnumerable<T> other)
                {
                    lock (this)
                    {
                        _set.UnionWith(other);
                        RebuildQuery();
                    }
                }
    
                [SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
                void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
                {
                    _set.GetObjectData(info, context);
                }
            }
    
            private static void Main(string[] args)
            {
                HashQueue<int> queue = new HashQueue<int>(5);
                queue.Add(1);
                queue.Add(2);
                queue.Add(3);
                queue.Add(4);
                queue.Add(5);
                queue.Add(6);
                queue.ProcessItems((i) => Console.Write(i));
                //foreach (int i in queue)
                //{
                //    Console.Write("{0}", i);
                //}
            }
        }
    }
