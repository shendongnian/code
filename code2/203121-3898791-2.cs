    public T Dequeue()
    {
        _readSema.WaitOne();                                   // A
        int index = Interlocked.Increment(ref _tail);          // B
        index %= _capacity;
        if (index < 0) index += _capacity;
        T ret = Interlocked.Exchange(ref _array[index], null); // C
        Interlocked.Decrement(ref _count);
        _writeSema.Release();                                  // D
        return ret;
    }
