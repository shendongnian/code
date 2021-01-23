    public sealed class MyType : IEquatable<MyType> {
        private readonly int foo;
        private readonly string bar;
        public int Foo { get { return foo; } }
        public string Bar { get { return bar; } }
        public MyType(int foo, string bar) {
            this.foo = foo; this.bar = bar;
        }
        public bool Equals(MyType other) {
           if(other == null) return false;
           return other.foo == this.foo && other.bar == this.bar;
        }
        public bool Equals(object other) {
           return Equals(other as MyType);
        }
        public int GetHashCode() {
           int result = 29;
           result = result * 13 + foo.GetHashCode();
           result = result * 13 + (bar == null ? 0 : bar.GetHashCode());
           return result;
        }
    }
