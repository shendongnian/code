    class Foo {
        private static readonly Foo @default =
            new Foo();
        public static Foo Default { get { return @default; } }
        public int A { get; set; }
        public string B { get; set; }
    }
