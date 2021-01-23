    public static class PropertyCache<T>
    {
        public static SomeType SomeName { get { return someField; } }
        static PropertyCache() {
            // init someField
        }
    }
    ...
    var foo = PropertyCache<Foo>.SomeName;
