	public static partial class JTokenExtensions
	{
		/// <summary>
		/// Removes all the elements that match the conditions defined by the specified predicate.
		/// </summary>
		public static void RemoveAll(this JArray array, Predicate<JToken> match)
		{
			if (array == null || match == null)
				throw new ArgumentNullException();
			array.ReplaceAll(array.Where(i => !match(i)).ToList());
		}
	}
