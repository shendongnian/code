    public T MyMethod<T>(T stub) where T : class {
        // ...
        return null;
    }
    public T? MyMethod<T>(T? stub) where T : struct {
        // ...
        return null;
    }
    // this will then compile...
    string s = MyMethod<string>(null);
    int? i = MyMethod<int>(null);
