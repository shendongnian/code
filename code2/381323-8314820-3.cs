    public IEnumerator<TKey> GetEnumerator()
    {
        // Since we want to iterate on the Key we specifiying the enumerator on keys
        return _Dictionary.Keys.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
