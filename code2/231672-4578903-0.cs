    public void SomeMethod {
        var duplicateItems = list.GetDuplicates();
        …
    }
    public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> source) {
		HashSet<T> itemsSeen = new HashSet<T>();
		HashSet<T> itemsYielded = new HashSet<T>();
		
		foreach (T item in source) {
			if (!itemsSeen.Add(item)) {
				if (itemsYielded.Add(item)) {
					yield return item;
				}
			}
		}
	}
