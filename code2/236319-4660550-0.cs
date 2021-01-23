    static class EnumerableExtension
    {
        public static IEnumerable<IEnumerable<T>> EachCons<T>(this IEnumerable<T> sequence, int cons)
        {
            for (IEnumerable<T> head = sequence.Take(cons), tail = sequence.Skip(1);
                 head.Count() == cons; head = tail.Take(cons), tail = tail.Skip(1))
                 yield return head;
        }
    }
