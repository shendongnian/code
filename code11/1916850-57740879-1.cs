    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    /// A <see cref="IEnumerator{T}"/> of <see cref="JToken"/> that can be used to iterate through the collection.
    /// </returns>
    public IEnumerator<JToken> GetEnumerator()
    {
        return Children().GetEnumerator();
    }
