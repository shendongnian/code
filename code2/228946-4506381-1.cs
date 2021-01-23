    public class VList<T> : IEnumerable<T>
    {
        VListNode<T> RootNode;
        public int Count { get; private set; }
        public VList() : this(4) { }
        public VList(int size)
        {
            RootNode = new VListNode<T>(4, null);
        }
        public void Add(T element)
        {
            if (RootNode.Count == RootNode.MaxSize)
                RootNode = new VListNode<T>(RootNode.MaxSize * 2, RootNode);
            RootNode.Add(element);
            Count++;
        }
        public void Clear()
        {
            RootNode = new VListNode<T>(4, null);
        }
        public IEnumerator<T> GetEnumerator()
        {
            VListNode<T> node = RootNode;
            while (node != null)
            {
                foreach (T t in node)
                    yield return t;
                node = node.Next;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
    public class VListNode<T> : IEnumerable<T>
    {
        readonly T[] Elements;
        public VListNode<T> Next { get; private set; }
        public int Count { get; private set; }
        public int MaxSize { get; private set; }
        public VListNode(int size, VListNode<T> next)
        {
            MaxSize = size;
            Elements = new T[size];
            Next = next;
        }
        public void Add(T element)
        {
            Elements[Count] = element;
            Count++;
        }
        public IEnumerator<T> GetEnumerator()
        {
            // iterate in reverse to return elements in LIFO order.
            for (int i = Count - 1; i >= 0; i--)
                yield return Elements[i];
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
