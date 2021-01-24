    public static void MoveElementToBack<T>(Queue<T> queue, int elementIndex)
    {
        T temp = default;
        for (int i = 0, n = queue.Count; i < n; ++i)
        {
            if (i == elementIndex)
                temp = queue.Dequeue();
            else
                queue.Enqueue(queue.Dequeue());
        }
        queue.Enqueue(temp);
    }
