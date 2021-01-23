    public void Add(T item)
    {
        if (this._size == this._items.Length)
        {
            this.EnsureCapacity(this._size + 1);
        }
        this._items[this._size++] = item;
        this._version++;
    }
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
