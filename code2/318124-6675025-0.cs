    class IntegerClass
    {
        private int value;
        public IntegerClass(int value)
        {
            this.value = value;
        }
        public void Reset()
        {
            this.value = default(int);
        }
    }
