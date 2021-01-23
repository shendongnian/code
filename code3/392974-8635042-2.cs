        class Class<T>  : IEnumerable
    {
        private List<T> list;
        public Class()
        {
            list = new List<T>();
        }
        public void Add(T d)
        {
            list.Add(d);
        }
        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
