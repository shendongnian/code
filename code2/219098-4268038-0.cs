    public static List<List<T>> GetChunks<T>(this IList<T> list, int chunkSize)
    {
        return Enumerable
                    .Range(0, list.Count / chunkSize)
                    .Select(i => Enumerable
                        .Range(0, chunkSize)
                        .Select(j => list[i * chunkSize + j])
                        .ToList())
                    .ToList();
    }
