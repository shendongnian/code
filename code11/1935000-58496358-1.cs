    static class EnumerableExtensions
    {
        public static LinkedList<T> ToLinkedList<T>(this IEnumerable<T> collection)
        {
            return new LinkedList<T>(collection);
        }
    }
