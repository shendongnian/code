    public static IEnumerable<T> MergeShufflePreservingOrder<T>(
        params IEnumerable<T>[] sources)
    {
        var random = new Random();
        var queues = sources
            .Select(source => new Queue<T>(source))
            .ToArray();
        var tokens = queues
            .SelectMany((queue, i) => Enumerable.Repeat(i, queue.Count))
            .ToArray();
        Shuffle(tokens);
        return tokens.Select(token => queues[token].Dequeue());
        void Shuffle(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int j = random.Next(i, array.Length);
                if (i == j) continue;
                if (array[i] == array[j]) continue;
                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
