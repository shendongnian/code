    public class QueueDictionary<TKey, TValue>
    {
      private readonly LinkedList<Tuple<TKey, TValue>> _queue =
        new LinkedList<Tuple<TKey, TValue>>();
  
      private readonly Dictionary<TKey, LinkedListNode<Tuple<TKey, TValue>>> 
        _dictionary = new Dictionary<TKey, LinkedListNode<Tuple<TKey, TValue>>>();
  
      private readonly object _syncRoot = new object();
      public TValue Dequeue()
      {
        lock (_syncRoot)
        {
          Tuple<TKey, TValue> item = _queue.First();
          _queue.RemoveFirst();
          _dictionary.Remove(item.Item1);
          return item.Item2;
        }
      }
      public TValue Dequeue(TKey key)
      {
        lock (_syncRoot)
        {
          LinkedListNode<Tuple<TKey, TValue>> node = _dictionary[key];
          _queue.Remove(node);
          return node.Value.Item2;
        }
      }
      public void Enqueue(TKey key, TValue value)
      {
        lock (_syncRoot)
        {
          LinkedListNode<Tuple<TKey, TValue>> node = 
            _queue.AddLast(new Tuple<TKey, TValue>(key, value));
          _dictionary.Add(key, node);
        }
      }
    }
