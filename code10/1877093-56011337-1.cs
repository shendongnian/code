    class CNodeSequenceComparer : IEqualityComparer<IEnumerable<CNode>>
    {
        public IEqualityComparer<CNode> CNodeComparer {get; set;}
        public bool Equals(IEnumerable<CNode> x, IEnumerable<CNode> y)
        {
            // returns true if same sequence, using CNodeComparer
            // TODO: implement
        }
    }
