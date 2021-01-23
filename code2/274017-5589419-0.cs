    class DataHolder<T>
    {
        private T datacontainer;
        public DataHolder(T input)
        {
            datacontainer = input;
        }
        public DataHolder() {}
        public T Data
        {
            get { return datacontainer; }
            set { datacontainer = value; }
        }
    }
