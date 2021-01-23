    public class MyClass {
        public MyClass() {
            MyProperty = new HoldsAReference(this);
        }
        public HoldsAReference MyProperty { get; private set; }
    }
