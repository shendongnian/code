     public void Remove(int data)
        {
          for(var cur = new Node {Next = Head}; cur.Next != null; cur = cur.Next)
          {
            if (cur.Next.Data != data) continue;
            if (cur.Next == Head)
              Head = Head.Next;
            else
            {
                cur.Next = cur.Next.Next;
            }
          }
        }
