    global::ConsoleApplication31.Foo Read2_Foo(bool isNullable, bool checkType) {
        // ...
        if (Reader.IsEmptyElement) {
            Reader.Skip();
            return Callback(o);
        }
        // ...
        return Callback(o);
    }
    private T Callback<T>(T value) {
        if (value is IDeserializationCallback)
            ((IDeserializationCallback)value).OnDeserialization(this);
        return value;
    }
