    public abstract class SomeCollection<T>
    {
        internal List<T> InternalList;
    
        public SomeCollection() { InternalList = new List<T>(); }
    
        public abstract void RemoveAll(T theValue);
    }
    
    public class ReferenceCollection<T> : SomeCollection<T> where T : class
    {
        public override void RemoveAll(T theValue)
        {
            InternalList.RemoveAll(x => x == theValue);
        }
    }
    
    public class ValueCollection<T> : SomeCollection<T> where T : struct
    {
        public override void RemoveAll(T theValue)
        {
            InternalList.RemoveAll(x => x.Equals(theValue));
        }
    }
