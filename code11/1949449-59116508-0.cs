c#
public static class Extensions
{
    public static List<T> TryGet<T>(this Dictionary<int, List<T>> dict, int key) {
        return dict.TryGetValue(key, out var output) ? output : new List<T>();
    }
}
