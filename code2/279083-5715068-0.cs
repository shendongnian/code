    public static IList<T> GetEmptyList<T>(this IEnumerable<T> source)
    {
        return new List<T>();
    }
    var emp = MyCollection.GetEmptyList();
