    public class ParentCollection<T> : IEnumerable<T> where T : Parent
    {
        protected List<T> _list = new List<T>();
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public virtual List<T> SomeSelectMethod()
        {
            List<T> list = new List<T>();
            // DO LOGIC HERE TO DETERMINE WHAT ITEMS WILL BE IN LIST
            return list;
        }
    }
    public class ChildACollection : ParentCollection<ChildA>
    {
        public void SomeChildMethod()
        {
        }
        //You have the method inherited.
    }
