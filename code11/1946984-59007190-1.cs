        public void Add(params int[] numbers)
        {
            arr = numbers;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)arr).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        var foo2 = new FooArray { 1, 2, 3, 4, 2309, 12 };
