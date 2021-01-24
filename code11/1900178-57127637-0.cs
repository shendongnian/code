    public interface IStack<T> {
        T Top();
        int Size();
        void Push(T element);
        void Pop();
        bool IsEmpty();
        }
    public class ListBasedStack<T> : IStack<T> {
        private List<T> mElements;
        
        public int Size() { return mElements.Count; }
        public T Top() { mElements(mElements.Count - 1); }
        public void Push(T element) { mElements.Add(element); }
        public void Pop() { mElements.Remove(mElements.Count - 1); }
        public bool IsEmpty() { return mElements.Count > 0; }
    }
    public class SetBasedStack<T> : IStack<T> {
        private Set<T> mElements;
        public int Size() { return mElements.Count; }
        public T Top() { mElements.Last(); }
        public void Push(T element) { mElements.Add(element); }
        public void Pop() { mElements.RemoveLast(); }
        public bool IsEmpty() { return mElements.Count > 0; }
    }
