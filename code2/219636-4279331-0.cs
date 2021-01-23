    public class SomeClass {
        private Type t;
        internal Type Type {
            set {
                if (t == null) t = value;
            }
        }
    }
