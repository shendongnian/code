    public IEnumerable<T> GetNonShared(this IEnumerable<IEnumerable<T>> lists)
    {        
        using (var iterator = lists.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                return new T[0]; // Empty
            }
            HashSet<T> union = new HashSet<T>(iterator.Current.ToList());
            HashSet<T> intersection = new HashSet<T>(union);
            while (iterator.MoveNext())
            {
                // This avoids iterating over it twice; it may not be necessary,
                // it depends on how you use it.
                List<T> list = iterator.Current.Toist();
                union.UnionWith(list);
                intersection = intersection.IntersectWith(list);
            }
            union.ExceptWith(intersection);
            return union;
        }
    }
