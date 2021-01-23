    public static IEnumerable<IEnumerable<T>> Subdivide(this IEnumerable<T> source, int groupsize) {
        using(var e = source.GetEnumerator()) {
            while(e.MoveNext())
                yield return Subgroup(e, groupSize);
        }
    }
    static IEnumerable<T> Subgroup<T>(IEnumerator<T> e, int size) {
        int c;
        while(e.MoveNext() && ++c < size)
           yield return e.Current;
    }
            
            
