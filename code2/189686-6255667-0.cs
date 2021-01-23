    struct Example<T>
    {
        private object obj;
        public T Obj
        {
            get
            {
                return (T)obj;
            }
            set
            {
                this.obj = value;
            }
        }
    }
