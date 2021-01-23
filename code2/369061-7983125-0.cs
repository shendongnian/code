    public class FooEnumerator : IEnumerator
    {
        #region IEnumerator Members
        public object Current
        {
            get { throw new NotImplementedException(); }
        }
        public bool MoveNext()
        {
            throw new NotImplementedException();
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
