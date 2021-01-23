    class Unit
    {
        public override bool Equals(object obj)
        {
            return true;
        }
        public override int GetHashCode()
        {
            return 0;
        }
    }
    public static class EnumerableEx
    {
        public static Unit ForEach<TSource>(
            this IEnumerable<TSource> source,
            Action<TSource> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
            return new Unit();
        }
    }
