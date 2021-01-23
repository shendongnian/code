    public static bool HaveSameItems<T>(IEnumerable<T> a, IEnumerable<T> b) {
        var dictionary = a.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        var e = b.GetEnumerator();
        while (e.MoveNext()) {
            int value;
            if (!dictionary.TryGetValue(e.Current, out value)) {
                   return false;
            }
            if (value == 0) {
                return false;
            }
            dictionary[e.Current] -= 1;
        }
        return dictionary.All(x => x.Value == 0);
    }
