      class RandomList<T> : IEnumerable<T> {
        private readonly IList<T> list;
        private readonly Random rg = new Random();
        public RandomList(IList<T> list) {
            this.list = list;
        }
        public IEnumerator<T> GetEnumerator() {
            var indexes = Enumerable.Range(0, list.Count).OrderBy(x => rg.Next());
            foreach (var index in indexes) {
                yield return list[index];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
