C#
public static class StringSplitterJoinner
{
    public static string Join(this string[] me, string separator, int start_index = 0, int? end_index = null)
    {
        if (!end_index.HasValue) end_index = me.Length - 1;
    }
}
