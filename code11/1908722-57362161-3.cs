    abstract class AMyAbstractClass {
        public readonly int MyReadonlyField;
        public int MyReadonlyProperty { get; }//syntactic sugar
        protected AMyAbstractClass (int fieldValue, int propertyValue) {
            this.MyReadonlyField = fieldValue;
            this.MyReadonlyProperty = propertyValue;
        }
    }
    class MyConcreteClass : AMyAbstractClass {
        public MyConcreteClass() 
            : base(fieldValue: 1, propertyValue:1) {
        }
    }
