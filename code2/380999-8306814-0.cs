        public class Foo
        {
            public virtual int GetFoosInt()
            {
                return 12;
            }
        }
        public class FooClient
        {
            private Foo _foo;
            public FooClient(Foo foo)
            {
                _foo = foo;
            }
            public int AddOneToFoosInt()
            {
                return _foo.GetFoosInt() + 1;
            }
        }
