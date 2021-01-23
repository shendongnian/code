    internal sealed class NotLockFreeYetQueue<T>
    {
      private sealed class Node
      {
        public readonly T Item;
        public Node Next{get;set;}
        public Node(T item)
        {
          Item = item;
        }
      }
      private Node _head;
      private Node _tail;
      public NotLockFreeYetQueue()
      {
        _head = _tail = new Node(default(T));
      }
      public void Enqueue(T item)
      {
        Node newNode = new Node(item);
        _tail.Next = newNode;
        _tail = newNode;
      }
      public bool TryDequeue(out T item)
      {
          if (_head == _tail)
          {
              item = default(T);
              return false;
          }
          else
          {
            item = _head.Next.Item;
            _head = _head.Next;
            return true;
          }
      }
    }
