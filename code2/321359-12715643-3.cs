    public class RepeatableEnumerable<T> : IEnumerable<T>
    {
        readonly List<T> innerList;
        IEnumerator<T> innerEnumerator;
        public RepeatableEnumerable( IEnumerator<T> innerEnumerator )
        {
            this.innerList = new List<T>();
            this.innerEnumerator = innerEnumerator;
        }
        public IEnumerator<T> GetEnumerator()
        {
            // 1. Yield all items already collected so far from the inner list.
            foreach( var item in innerList ) yield return item;
            // 2. If the wrapped enumerator has more items
            if( innerEnumerator != null )
            {
                // 2A. while the wrapped enumerator can move to the next item
                while( innerEnumerator.MoveNext() )
                {
                    // 1. Get the current item from the inner enumerator.
                    var item = innerEnumerator.Current;
                    // 2. Add the current item to the inner list.
                    innerList.Add( item );
                    // 3. Yield the current item
                    yield return item;
                }
            }
            // 3. Mark the inner enumerator as having no more items.
            innerEnumerator = null;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    // Add extension methods and appropriate optimizations where the wrapped parameter is already repeatable.
    public static class RepeatableEnumerableExtensions
    {
        public static RepeatableEnumerable<T> ToRepeatable<T>( this IEnumerable<T> items )
        {
            var result = ( items as RepeatableEnumerable<T> )
                ?? new RepeatableEnumerable<T>( items.GetEnumerator() );
            return result;
        }
    }
