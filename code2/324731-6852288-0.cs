    public static IEnumerable<IEnumerable<T>> ToChunks<T>(this IEnumerable<T> enumerable, int chunkSize)
	{
		int itemsReturned = 0;
		var list = enumerable.ToList(); // Prevent multiple execution of IEnumerable.
		int count = list.Count;
		while (itemsReturned < count)
		{
			int currentChunkSize = Math.Min(chunkSize, count - itemsReturned);
			yield return list.Skip(itemsReturned).Take(currentChunkSize);
			itemsReturned += currentChunkSize;
		}
	}
