    public class MyClass : ICloneable {
        object ICloneable.Clone() {
           return this.Clone();
        }
        public MyClass Clone() {
           return new MyClass() { ... };
        }
    }
