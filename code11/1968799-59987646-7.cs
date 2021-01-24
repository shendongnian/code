    class StaticArrayModel : IEnumerable<bool>
    {
        private readonly bool[] _states;
        private int _startIndex;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="states">Initial states</param>
        public StaticArrayModel(IEnumerable<bool> states)
        {
            _states = states.ToArray();
        }
        /// <summary>
        /// Made light move forward 
        /// </summary>
        public void Increment()
        {
            _startIndex++;
            if (_startIndex == _states.Length)
                _startIndex = 0;
        }
        /// <summary>
        /// Made light move backward 
        /// </summary>
        public void Decrement()
        {
            _startIndex--;
            if (_startIndex < 0)
                _startIndex = _states.Length - 1;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<bool> GetEnumerator()
        {
            for (var i = 0; i < _states.Length; i++)
            {
                var j = i + _startIndex;
                j %= _states.Length;
                yield return _states[j];
            }
        }
    }
