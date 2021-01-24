    abstract class AMyAbstractClass {
        public readonly int MyReadonlyField;
        public int MyReadonlyProperty { get; }//syntactic sugar
        public AMyAbstractClass (int fieldValue) {
            this.MyReadonlyField = fieldValue;
        }
    }
    class MyConcreteClass : AMyAbstractClass {
        MyConcreteClass() {
            base(fieldValue: 1);
        }
    }
