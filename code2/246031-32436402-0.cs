    public static IEnumerable<T> ConcatSingle<T>(this IEnumerable<T> enumerable, T value) {
       return enumerable.Concat(value.Yield());
    }
    public static IEnumerable<T> Yield<T>(this T item) {
        yield return item;
    }
