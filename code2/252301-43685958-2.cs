    public static class Utilities
    {
		/// <summary>
		/// Determines whether a sequence has a value and contains any elements.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <param name="source">The <see cref="System.Collections.Generic.IEnumerable"/> to check for emptiness.</param>
		/// <returns>true if the source sequence is not null and contains any elements; otherwise, false.</returns>
		public static bool AnyNotNull<TSource>(this IEnumerable<TSource> source)
		{
			return source?.Any() == true;
		}
		/// <summary>
		/// Determines whether a sequence has a value and any element of a sequence satisfies a condition.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <param name="source">An <see cref="System.Collections.Generic.IEnumerable"/> whose elements to apply the predicate to.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>true if the source sequence is not null and any elements in the source sequence pass the test in the specified predicate; otherwise, false.</returns>
		public static bool AnyNotNull<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			return source?.Any(predicate) == true;
		}
    }
