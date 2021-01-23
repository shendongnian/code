    public class MyClass {
        public bool IsSomethingTrue { get; set; } // with notification on property changed
        public bool IsSomethingFalse { get { return !IsSomethingTrue; } }
    
        private AMethod() {
            ...
            IsSomethingTrue = Something > 0;
            ...
        }
