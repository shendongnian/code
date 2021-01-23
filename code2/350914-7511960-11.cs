    public class ProjectionIndexable<Tsrc, Ttarget> : IIndexable<Ttarget>
    {
        public ProjectionIndexable
             (IIndexable<Tsrc> src, Func<Tsrc, Ttarget> projection)
        {
            _src = src;
            _projection = projection;
        }
        #region IIndexable<Ttarget> Members
        public Ttarget this[int index]
        {
            get { return _projection(_src[index]); }
        }
        public int Length
        {
            get { return _src.Length; }
        }
        #endregion
        #region IEnumerable<Ttarget> Members
        // create your own enumerator here
        #endregion
    }
