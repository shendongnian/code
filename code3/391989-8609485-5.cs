    public class Foo<T> where T : new()
    {
        private T _t = new T(); // can only construct T if have new() constraint
    }
    public class ValueFoo<T> where T : struct
    {
        private T? _t; // to use nullable, T must be value type, constrains with struct
    }
    public class RefFoo<T> where T : class
    {
        private T _t = null;  // can only assign type T to null if ref (or nullable val)
    }
