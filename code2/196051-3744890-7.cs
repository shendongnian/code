    static void Go(int depth)
    {
        if (depth == pairs.Length)
        {
            results.Add(currResult.Reverse().ToArray());
        }
        else
        {
            var indexes = pairs[depth].Indexes;
            for (int i = 0; i < indexes.Length; i++)
            {
                if (depth == 0 || indexes[i] > currResult.Last())
                {
                    currResult.Push(indexes[i]);
                    Go(depth + 1);
                    currResult.Pop();
                }
            }
        }
    }
