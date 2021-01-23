    class Program
    {
        static void Main(string[] args)
        {
            var b = 6;
            var t = (dynamic)new T();
            var n = t.Foo(b);
        }
        class T
        {
            public string Foo<T>(T a)
            {
                return typeof(T).Name;
            }
        }
    }
