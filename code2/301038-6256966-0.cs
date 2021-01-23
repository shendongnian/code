    #region IEnumerable<T> Members
    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        for (int i = 0; i < _sourceIndices.Count; i++)
            yield return _sourceIndices[i].Key.Item.Object;
    }
    #endregion
