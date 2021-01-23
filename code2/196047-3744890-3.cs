    static void Go(int depth)
    {
        if (depth == pairs.Length)
        {
            results.Add(currResult.ToArray());
        }
        else
        {
            var indexes = pairs[depth].Indexes;
            for (int i = 0; i < indexes.Length; i++)
            {
                if (depth == 0 || indexes[i] > currResult.Last())
                {
                    currResult.Enqueue(indexes[i]);
                    Go(depth + 1);
                    currResult.Dequeue();
                }
            }
        }
    }
