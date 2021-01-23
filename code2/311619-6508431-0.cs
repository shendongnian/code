    public class FriendlyEnumerable<T> : IEnumerable<T>
    {
        private IEnumerable<T> _enum;
        public FriendlyEnumerable(IEnumerable<T> enumerable) 
        {            
            _enum = enumerable;
        }
        public void VisitAll(Action<T, T> visitFunc)
        {
            VisitAll(visitFunc, 1);
        }
        public void VisitAll(Action<T, T> visitFunc, int lookahead)
        {
            int index = 0;
            int length = _enum.Count();
            _enum.ToList().ForEach(t =>
            {
                for (int i = 0; i < lookahead; i++)
                    visitFunc(t, _enum.ElementAt((index + i) % length));
            });
        }
        #region IEnumerable<T> Members
        public IEnumerator<T> GetEnumerator()
        {
            return _enum.GetEnumerator();
        }
        #endregion
    }
