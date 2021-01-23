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
        public static Unit ForEach&lt;TSource&gt;(
            this IEnumerable&lt;TSource&gt; source,
            Action&lt;TSource&gt; action)
        {
            foreach (var item in source)
            {
                action(item);
            }
            return new Unit();
        }
    }
