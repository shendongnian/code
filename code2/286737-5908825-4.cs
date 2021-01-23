    public static class FooFluentExtensions
    {
        public static T SetMyProperty<T>(this T foo) where T : BaseFoo
        {
            foo.MyProp = true;
            return foo;
        }
        public static T SetDerivedPropery<T>(this T foo) where T : DerivedFoo
        {
            foo.DerivedProp = true;
            return foo;
        }
    }
    static void Main()
    {
        DerivedFoo foo = new DerivedFoo();
        // works, because SetMyProperty returns DerivedFoo
        foo.SetMyProperty().SetDerivedPropery();
        BaseFoo baseFoo = new BaseFoo();
        baseFoo.SetMyProperty();
        // doesn't work (and that's correct), because SetMyProperty returns BaseFoo
        // baseFoo.SetMyProperty().SetDerivedPropery();
    }
