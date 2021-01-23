public static bool AllEqual<T1, T2>(this IEnumerable<T1> enumerable, Func<T1, T2> selector)
{
    using (var enumerator = enumerable.GetEnumerator())
    {
        if (!enumerator.MoveNext())
            return false;
        var first = selector(enumerator.Current);
        while (enumerator.MoveNext())
        {
            if (selector(enumerator.Current).Equals(first) == false)
                return false;
        }
    }
    return true;
}
