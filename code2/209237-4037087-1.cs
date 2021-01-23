    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return _lstInternal.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return _lstInternal.GetEnumerator();
    }
