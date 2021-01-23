    public class ClassA {
        public virtual string Name {
            get;
            private set;
        }
    }
    public class ClassB : ClassA {
        public override string Name {
            get {
                return base.Name;
            }
        }
    }
