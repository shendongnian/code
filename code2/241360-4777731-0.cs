    public void RemoveAt(int index)
    {
        if (index >= this._size)
        {
            ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        this._size--;
        if (index < this._size)
        {
            Array.Copy(this._items, index + 1, this._items, index, this._size - index);
        }
        this._items[this._size] = default(T);
        this._version++;
    }
