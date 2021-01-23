    class T : IEnumerable<int> {
        public IEnumerator<int> GetEnumerator() {
            int i = 0;
            while(i < 5) {
                yield return i;
                i++;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
