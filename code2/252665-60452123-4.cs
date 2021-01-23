    namespace System.Collections.Generic
    {
        [DebuggerDisplay("Count = {Count}")]
        [DebuggerTypeProxy(typeof(Generic.Mscorlib_CollectionDebugView<>))]
        [DefaultMember("Item")]
        public class List<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection, IReadOnlyList<T>, IReadOnlyCollection<T>
        {
            ...
            public T this[int index] { get; set; }
            public int Count { get; }
            public int Capacity { get; set; }
            public void Add(T item);
            public void AddRange(IEnumerable<T> collection);
            ...
        }
    }
