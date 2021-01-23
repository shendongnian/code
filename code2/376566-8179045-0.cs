    static class Arrays
    {
        public static void Each<T>(this Array a,
                                   Action<int[], T> proc,
                                   int[] startAt = null)
        {
            int rank = startAt == null ? 0 : startAt.Length;
            int[] indices = new int[rank + 1];
            if (rank > 0)
                startAt.CopyTo(indices, 0);
            for (int i = a.GetLowerBound(rank); i <= a.GetUpperBound(rank); i++)
            {
                indices[rank] = i;
                if (rank == a.Rank - 1)
                    proc(indices, (T)a.GetValue(indices));
                else
                    Each(a, proc, indices);
            }
        }
    }
