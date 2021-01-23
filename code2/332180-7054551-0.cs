    class StringCollection : IList
    {
        ...
        public void Add(string value)
        {} // implementation
        
        public void IList.Add (object value)
        {
            if (!value is string)) throw ...
            Add(value as string)
        }
    }
