    class Animal {
        public abstract string PropertyValue { get; set; }
    }
    class Cat : Animal {
        public override string PropertyValue {
            get { return PurrStrength; }
            set { PurrStrength = value; }
        }
    }
