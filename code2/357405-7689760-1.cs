    public void DeleteNode(int x, LinkedList<name> myLinkedList) {
        var node = myLinkedList.First;
        while (node != null) {
            var nextNode = node.Next;
            if (node.Value.num == x) {
                myLinkedList.Remove(node);
            }
            node = nextNode;
        }
    }
