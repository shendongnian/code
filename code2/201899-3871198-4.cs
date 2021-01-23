    private sealed class Node
    {
      public readonly T Item;
      public Node Next;
      public Node(T item)
      {
        Item = item;
      }
    }
    /* ... */
    private volatile Node _tail;
    /* ... */
    public void Enqueue(T item)
    {
      Node newNode = new Node(item);
      for(;;)
      {
        Node curTail = _tail;
        if(Interlocked.CompareExchange(ref curTail.Next, newNode, null) == null)
        {
          _tail = newNode;
          return;
        }
      }
    }
