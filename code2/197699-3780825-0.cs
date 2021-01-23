    public static class EnumerableExtensions
    {
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int count)
        {
            if (count < 1) throw new ArgumentOutOfRangeException("count");
    
            Queue<T> queue = new Queue<T>(); //You may use count as a default capacity
    
            foreach (var t in source)
            {
                queue.Enqueue(t);
    
                if (queue.Count > count) queue.Dequeue();
            }
    
            foreach (var t in queue)
            {
                yield return t;
            }
        }
    }
