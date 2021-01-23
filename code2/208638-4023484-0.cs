    public class ExternalClass
    {
        private InternalClass numberHolder;
        public ExternalClass() {
            numberHolder = new InternalClass();
        }
        public int MyNumber {
            get {
                return numberHolder.SomeNumber;
            }
            set {
                numberHolder.SomeNumber = value;
            }
        }
        private class InternalClass
        {
            public int SomeNumber { get; set; }
        }
    }
