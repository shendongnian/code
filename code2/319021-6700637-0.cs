	var resultSequence = sourceSequence.WithCancellation(cancellationToken)
							.Select(myExpensiveProjectionFunction)
							.ToList();
	static class CancelExtention
	{
		public static IEnumerable<T> WithCancellation<T>(this IEnumerable<T> en, CancellationToken token)
		{
			foreach (var item in en)
			{
				token.ThrowIfCancellationRequested();
				yield return item;
			}
		}
	}
