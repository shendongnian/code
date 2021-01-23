    namespace System
    {
        abstract class Array : IEnumerable
        {
            public IEnumerator GetEnumerator() { ... }
            ...
        }
    }
    
    class object[] : System.Array, IList<object>, IEnumerable<object>
    {
        IEnumerator<object> IEnumerable<object>.GetEnumerator() { ... }
        int IList<object>.Count { get { ... } }
        ...
    }
