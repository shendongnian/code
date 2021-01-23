    public abstract class BaseTimeCollection : ICollection<Time>
    {
        protected abstract IEnumerator IEnumerable_GetEnumerator();
        protected abstract IEnumerator<Time> GenericEnumerable_GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() 
        { 
            return IEnumerable_GetEnumerator(); 
        }
        IEnumerator<Time> IEnumerable<Time>.GetEnumerator()
        {
            return GenericEnumerable_GetEnumerator();
        }
    }
