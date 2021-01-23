    Dictionary<int, object> locks = new Dictionary<int, object>();
    locks.Add(1, new object());
    locks.Add(2, new object());
    
    void Foo(int bar)
    {
        lock (locks[bar]) {
            …
        }
    }
