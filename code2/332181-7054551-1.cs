    class StringCollection : IList
    {
        ...
        public int Add(string value)
        {} // implementation
        
        public int IList.Add (object value)
        {
            if (!value is string)) return -1;
            return Add(value as string)
        }
    }
