    public class MySpecialList<T> : IEnumerable<T>
    {
        // if we access from any other reference, we get the new, generic
        // interface
        public IEnumerator<T> GetEnumerator()
        {
            // your actual implementation
        }
        // so if we access from a reference of IEnumerable, we get older,
        // non-generic interface
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
