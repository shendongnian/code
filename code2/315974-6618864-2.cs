    public class DelegateList<T> : IEnumerable<MyDelegate<T>>
    {
        // ...other class details 
        private List<MyDelegate<T>> imp = new List<MyDelegate<T>>();
        public IEnumerator<MyDelegate<T>> GetEnumerator()
        {
            return imp.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
