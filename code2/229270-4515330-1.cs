    struct Number
    {
        int value;
        public Number(int value) { this.value = value; }
        public int Value { get { return value; } }
        // iterator that mutates "this"
        public IEnumerable<int> UpTo(int max)
        {
            for (; value <= max; value++)
                yield return value;
        }
    }
