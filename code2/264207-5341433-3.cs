    public ListNode InsertAfterCurrent(object name, object code)
    {
      if (currentNode == null)
      {
        //assume new list
        currentNode = firstNode = lastNode = new ListNode(name, code, null);
      }
      else
      {
        currentNode.NextNode = new ListNode(name, code, currentNode.NextNode);
      }
    }
    
    public ListNode InsertAfter(ListNode anchor, object name, object code)
    {
      if (anchor != null  && NodeIsPartOfList(anchor))
      {
        anchor.NextNode = new ListNode(name, code, anchor.NextNode);
      }
    }
    
    public bool NodeIsPartOfList(ListNode node)
    {
      var current = firstNode;
      while (current != null)
      {
        if (current == node)
          return true;
        current = current.NextNode;
      }
      return false;
    }
