    public static void MoveElementToBack<T>(Queue<T> queue, T elementToMove)
    {
        T item = default;
        bool found = false;
        for (int i = 0, n = queue.Count; i < n; ++i)
        {
            var current = queue.Dequeue();
            if (!found && current.Equals(elementToMove))
            {
                item  = current;
                found = true;
            }
            else
            {
                queue.Enqueue(current);
            }
        }
        if (found)
            queue.Enqueue(item);
    }
