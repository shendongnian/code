        public void Add(object newItem, object After)
        {
            if (IsEmpty())
            {
                InsertAtFront(newItem);
                return;
            }
            ListNode newNode = new ListNode();
            ListNode current = Find(After);
            newNode.Next = current.Next;
            current.Next = newNode;
        }
