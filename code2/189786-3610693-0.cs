    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            // ...
            list.ForNext(1, DoWorkForFirst).ForRemainder(DoWork);
        }
        static void DoWorkForFirst(string s)
        {
            // do work for first item
        }
        static void DoWork(string s)
        {
            // do work for remaining items
        }
    }
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ForNext<T>(this IEnumerable<T> enumerable, int count, Action<T> action)
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");
            using (var enumerator = enumerable.GetEnumerator())
            {
                // perform the action for the first <count> items of the collection
                while (count > 0)
                {
                    if (!enumerator.MoveNext())
                        throw new ArgumentOutOfRangeException(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Unexpected end of collection reached.  Expected {0} more items in the collection.", count));
                    action(enumerator.Current);
                    count--;
                }
                // return the remainder of the collection via an iterator
                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
            }
        }
        public static void ForRemainder<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null)
                throw new ArgumentNullException("enumerable");
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
    }
