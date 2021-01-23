    public static int RemoveAll<T>(this LinkedList<T> list, Predicate<T> match)
    {
        if (list == null)
        {
            throw new ArgumentNullException("list");
        }
        if (match == null)
        {
            throw new ArgumentNullException("match");
        }
        var count = 0;
        var node = list.First;
        while (node != null)
        {
            var next = node.Next;
            if (match(node.Value))
            {
                list.Remove(node);
                count++;
            }
            node = next;
        }
        return count;
    }
