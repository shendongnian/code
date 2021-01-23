    public class PClass {
        protected PClass() {
            // do nothing
        }
        public PClass(int myIntArg) {
            // initialize the class
        }
    }
    public Class CClass : PClass {
        public CClass(string myStringArg) : base() {
            // initialize the class
        }
    }
