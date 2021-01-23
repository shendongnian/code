        public void Enqueue(UInt64 key, T item)
        {
            while (queue.Count >= MaximumSize)
                Thread.Sleep(TimeSpan.Zero);
            lock (queue)
            {
                queue.Add(key, item);
                if (queue.Count > PeakSize)
                    PeakSize = queue.Count;
                Monitor.Pulse(queue);
            }
        }
        /// <summary>
        /// Returns an item from the queue, when an item becomes available.
        /// </summary>
        /// <returns>The next item in the queue.</returns>
        public T Dequeue()
        {
            lock (queue)
            {
                while (!flushed && queue.Count < MinimumSize)
                    Monitor.Wait(queue);
                var item = queue.First();
                T value = item.Value;
                queue.Remove(item.Key);
                return value;
            }
        }
