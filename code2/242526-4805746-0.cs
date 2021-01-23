    class Sequence : IEnumerable<int> {
        public IEnumerator<int> GetEnumerator() {
            for (int i = 0; i < 17; i++) {
                Console.WriteLine(i);
                yield return i;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
