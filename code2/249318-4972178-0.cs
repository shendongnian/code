    public IEnumerator<T> GetEnumerator()
    {
        // Return real iterator
    }
    // Explicit implementation of nongeneric interface
    IEnumerator IEnumerable.GetEnumerator()
    {
        // Delegate to the generic implementation
        return GetEnumerator();
    }
