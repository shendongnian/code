    class CustomCollection
    {
        public CustomEnumerator GetEnumerator()
        {
            return new CustomEnumerator();
        }
    }
    class CustomEnumerator
    {
        public bool MoveNext()
        {
            return (++this.Current <= 10);
        }
        public int Current { get; private set; }
    }
