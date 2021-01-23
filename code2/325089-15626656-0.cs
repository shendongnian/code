    public abstract class BaseTimeCollection<Time> : ICollection<Time>
    {
        public abstract IEnumerator<Time> GetEnumerator(); // implicit, generic and abstract
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        // Other ICollection methods (Add, Clear, etc) ...
    }
