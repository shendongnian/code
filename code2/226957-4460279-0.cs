    partial class Kind
    {
        public IEnumerable<Kind> Ancestors
        {
            get
            {
                for (var p = BaseKind; p != null; p = p.BaseKind)
                    yield return p;
            }
        }
        public IEnumerable<Kind> ThisAndAncestors
        {
            get
            {
                for (var p = this; p != null; p = p.BaseKind)
                    yield return p;
            }
        }
    }
