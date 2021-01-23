    class Parallel
    {
        public static void ForEach<T>(IEnumerable<T> source, Action<T> body)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (body == null)
            {
                throw new ArgumentNullException("body");
            }
            var items = new List<T>(source);
            var countdown = new CountdownEvent(items.Count);
            WaitCallback callback = state =>
            {
                try
                {
                    body((T)state);
                }
                finally
                {
                    countdown.Signal();
                }
            };
            foreach (var item in items)
            {
                ThreadPool.QueueUserWorkItem(callback, item);
            }
            countdown.Wait();
        }
    }
