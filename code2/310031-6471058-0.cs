    public class ClassA {
        public virtual string Foo { get; set };
        public virtual ClassA GetAsClassA() {
            return this;
        }
    }
    public class ClassB : ClassA {
        public virtual string Foo { get; set };
        public override ClassA GetAsClassA() {
            // Create new ClassA and copy properties as needed.
            // Can use base.Foo to get base properties, as needed.
        }
    }
