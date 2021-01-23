    class NodeFull : IEnumerable<int>
    {
        ... other stuff as normal ...
        public IEnumerator<int> GetEnumerator()
        {
            return children.GetEnumerator();
        }
        // Use explicit interface implementation as there's a naming
        // clash. This is a standard pattern for implementing IEnumerable<T>.
        IEnumerator IEnumerable.GetEnumerator()
        {
            // Defer to generic version
            return GetEnumerator();
        }
    }
