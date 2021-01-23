    public void Clear()
    {
        if (this._size > 0)
        {
            Array.Clear(this._items, 0, this._size);
            this._size = 0;
        }
        this._version++;
    }
