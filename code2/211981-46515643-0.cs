    public ImmutableList<T> Add(T item)
    {
        // Create a new list with the added item
    }
    IImmutableList<T> IImmutableList<T>.Add(T value) => this.Add(value);
    void ICollection<T>.Add(T item) => throw new NotSupportedException();
    int IList.Add(object value) => throw new NotSupportedException();
