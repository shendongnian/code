    var yourList = new List<DateTime?>
                       {
                           null,
                           new DateTime(2011, 1, 23),
                           null,
                           new DateTime(2011, 1, 18)
                       };
    var comparer = new NullsLastComparer<DateTime?>();
    yourList.Sort(comparer);  // now contains { 18/01/2011, 23/01/2011, null, null }
    // ...
    public sealed class NullsLastComparer<T> : Comparer<T>
    {
        public override int Compare(T x, T y)
        {
            if ((x == null) && (y == null))
                return 0;
            if (x == null)
                return 1;
            if (y == null)
                return -1;
            return Comparer<T>.Default.Compare(x, y);
        }
    }
