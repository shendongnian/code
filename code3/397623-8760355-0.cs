    public IEnumerator<T> GetEnumerator () { whatever }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
