    public static class ValueTupleListExtensions
    {
        public static void Add<T1, T2>(this IList<Tuple<T1, T2>> list,
            ValueTuple<T1, T2> item) => list.Add(item.ToTuple());
    }
