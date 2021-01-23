    public class Node<T> : IEnumerable<T>
    {
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }
        public T Data { get; set; }
        public IEnumerator<T> GetEnumerator()
        {
            yield return Data;
            if (LeftChild != null)
            {
                foreach (var child in LeftChild)
                    yield return child;
            }
            if (RightChild != null)
            {
                foreach (var child in RightChild)
                    yield return child;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
