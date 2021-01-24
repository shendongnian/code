        public static System.Collections.Generic.IEnumerable<TResult> Select<TSource, TResult>(this System.Collections.Generic.IEnumerable<TSource> source, int size, System.Func<Queue<TSource>, TSource, Queue<TSource>, TResult> selector)
        {
            if (source == null)
            {
                throw new System.ArgumentNullException("source");
            }
            if (selector == null)
            {
                throw new System.ArgumentNullException("selector");
            }
            Queue<TSource> prevQueue = new Queue<TSource>(size);
            Queue<TSource> nextQueue = new Queue<TSource>(size);
            int i = 0;
            foreach (TSource item in source)
            {
                nextQueue.Enqueue(item);
                if (i++ >= size)
                {
                    TSource it = nextQueue.Dequeue();
                    yield return selector(prevQueue, it, nextQueue);
                    prevQueue.Enqueue(it);
                    if (prevQueue.Count > size)
                    {
                        prevQueue.Dequeue();
                    }
                }
            }
            while (nextQueue.Any())
            {
                TSource it = nextQueue.Dequeue();
                yield return selector(prevQueue, it, nextQueue);
                prevQueue.Enqueue(it);
                if (prevQueue.Count > size)
                {
                    prevQueue.Dequeue();
                }
            }
        }
