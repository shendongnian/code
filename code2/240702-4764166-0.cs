    class Enumerate : IEnumerable
    {
        private Enumerate IEnumerator it;
        public Enumerate(IEnumerator it) { this.it = it; }
        public IEnumerator GetEnumerator() { return this.it; }
    }
