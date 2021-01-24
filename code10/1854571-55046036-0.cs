 csharp
        /// <summary>
        /// Enqueues the given object.
        /// If the new queue size would be greater than <paramref name="capacity"/> then
        /// this method makes room for the new item by dequeueing until there is a spot.
        /// </summary>
        /// <typeparam name="T">The type of object to enqueue.</typeparam>
        /// <param name="queue">The queue to apply this extension on.</param>
        /// <param name="item">The object to enqueue.</param>
        /// <param name="capacity">
        /// The maximum queue capacity to enforce.
        /// If the new queue size would be greater than this value then items are dequeued until there is space for the new item.
        /// This value must greater than zero.
        /// </param>
        public static void Enqueue<T>(this Queue<T> queue, T item, int capacity)
        {
            if (queue == null) throw new ArgumentNullException(nameof(queue));
            if (capacity < 1) throw new ArgumentOutOfRangeException(nameof(capacity), capacity, $"Capacity is {capacity} but must be greater than zero.");
            // make room for the new item
            while (queue.Count > capacity - 1)
            {
                queue.Dequeue();
            }
            // enqueue the new item
            queue.Enqueue(item);
        }
The above said, the main blocker to efficiency there appears to be the full deserializing and re-serializing to JSON. What is the reason that needs to happen?
