    static IEnumerable<LinkedListNode<T>> AsEnumerable<T>
        (this LinkedListNode<T> node)
    {
        // Can even call list.Head.AsEnumerable() when the list is empty!
        while (node != null)
        {
            yield return node;
            node = node.Next;
        }
    }
    static IEnumerable<LinkedListNode<T>> ReverseEnumerable<T>
        (this LinkedListNode<T> node)
    {
        while (node != null)
        {
            yield return node;
            node = node.Previous;
        }
    }
