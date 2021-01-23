    public static List<T> Sample<T>(this List<T> list, int n)
    {
        return list.Sample(list.Count / n).ToList();
    }
    public static IEnumerable<T> Sample<T>(this IEnumerable<T> enumerable, int interval) {
        var index = 0;
        foreach (var item in enumerable) {
            if (index == 0) {
                yield return item;
            }
            if (++index == interval) index = 0;
        }
    }
