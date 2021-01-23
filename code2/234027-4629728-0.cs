    public virtual int Capacity
    {
        get
        {
            if (!this._isOpen)
            {
                __Error.StreamIsClosed();
            }
            return (this._capacity - this._origin);
        }
        [SecuritySafeCritical]
        set
        {
            if (value < this.Length)
            {
                throw new ArgumentOutOfRangeException("value", Environment.GetResourceString("ArgumentOutOfRange_SmallCapacity"));
            }
            if (!this._isOpen)
            {
                __Error.StreamIsClosed();
            }
            if (!this._expandable && (value != this.Capacity))
            {
                __Error.MemoryStreamNotExpandable();
            }
            if (this._expandable && (value != this._capacity))
            {
                if (value > 0)
                {
                    byte[] dst = new byte[value];
                    if (this._length > 0)
                    {
                        Buffer.InternalBlockCopy(this._buffer, 0, dst, 0, this._length);
                    }
                    this._buffer = dst;
                }
                else
                {
                    this._buffer = null;
                }
                this._capacity = value;
            }
        }
    }
