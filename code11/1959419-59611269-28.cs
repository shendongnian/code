    public struct IteratorEnum<A> : Iterator<IEnumerator<A>, A>
    {
        public bool HasNext(IEnumerator<A> iter) =>
            iter.MoveNext();
        public A Next(IEnumerator<A> iter) =>
            iter.Current;
    }
