    public static class Foo
    {
        public static object FooMethod(object source, Type fooType)
        {
            return typeof(Foo<>).MakeGenericType(fooType)
                .GetMethod("FooMethod").Invoke(null, new object[] { source });
        }
    }
