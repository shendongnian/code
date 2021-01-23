       public void Add(object newItem, object After)
       {
           if(IsEmpty())
           {
                InsertAtFront(newItem);
                return;
           }
    
           ListNode newNode=new ListNode();
           newNode.Data = newItem; 
           ListNode current = Find(After);
           newNode.Next = current.Next;
           current.Next = newNode;
       }
     
