        // This is your specific version, like List<T> does
        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
        // This is the one with the return value IEnumerator<T> expects
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }
        // Plus, it also expects this as well to satisfy IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
