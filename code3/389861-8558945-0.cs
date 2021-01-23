    class Parallel
    {
        public static void ForEach<T>(IEnumerable<T> source, Action<T> body)
        {
            WaitCallback callback = state => body((T)state);
            foreach (T item in source)
            {
                ThreadPool.QueueUserWorkItem(callback, item);
            }
        }
    }
