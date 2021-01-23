    public IEnumerator<T> GetEnumerator()
    {
        for (var i = _offset; i < _offset + _length; i++)
            yield return _array[i];
    }
    // either
    public IEnumerator<char> GetCharEnumerator()
    {
        for (var i = _offset; i < _offset + _length; i++)
            yield return _array[i].ToChar(null);
    }
    // or
    public IEnumerable<char> AsCharSequence()
    {
        for (var i = _offset; i < _offset + _length; i++)
            yield return _array[i].ToChar(null);
    }
