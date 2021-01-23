    class Node
    {
        Node next;
        Object data;
    }
    class Stack {
      Node Top;
      public Node Pop()
      {
        if(Top==null)
           return null;
        Node n = Top;
        Top = Top.Next;
        return n;
      }
      public void Push(Object i)
      {
        Node n = new Node(i);
        n.Next = Top;
        Top = n;
      }
    }
