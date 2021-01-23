    public class Permuter<T> : IEnumerable<IEnumerable<T>>
    {
        private readonly IEnumerable<T> _sequence;
        public Permuter(IEnumerable<T> sequence)
        {
            _sequence = sequence;
        }
        public IEnumerator<IEnumerable<T>> GetEnumerator()
        {
            foreach(var item in _sequence)
            {
                var remaining = _sequence.Except(Enumerable.Repeat(item, 1));
                foreach (var permutation in new Permuter<T>(remaining))
                    yield return Enumerable.Repeat(item, 1).Concat(permutation);
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
