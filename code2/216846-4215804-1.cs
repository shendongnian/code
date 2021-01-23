    public static class Foo<TFoo>
    {
        public static TFoo FooMethod(object source)
        {
            return (TFoo)Foo.FooMethod(source, typeof(TFoo));
        }
    }
