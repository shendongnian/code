    public delegate bool CompareValue<in T1, in T2>(T1 val1, T2 val2);
    public static bool CompareTwoArrays<T1, T2>(this IEnumerable<T1> array1, IEnumerable<T2> array2, CompareValue<T1, T2> compareValue)
    {
        return array1.Select(item1 => array2.Any(item2 => compareValue(item1, item2))).All(search => search);
    }
