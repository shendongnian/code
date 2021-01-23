    sealed class MyLazy<T>
    {
        private readonly Func<T> valueFactory;
        private T value;
        private bool valueCreated;
        public MyLazy(Func<T> valueFactory)
        {
            if (valueFactory == null)
            {
                throw new ArgumentNullException("valueFactory");
            }
            this.valueFactory = valueFactory;
        }
        public bool IsValueCreated
        {
            get { return this.valueCreated; }
        }
        public T Value
        {
            get
            {
                if (!this.valueCreated)
                {
                    this.value = this.valueFactory();
                    this.valueCreated = true;
                }
                return this.value;
            }
        }
    }
