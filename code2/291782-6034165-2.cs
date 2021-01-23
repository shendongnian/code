    public abstract class Child : Base
    {
        private ChildProperty1 _bp1;
        public BaseProperty1 bp1
        {
            get { return _bp1; }
            
            // Setter will be tricky. This implementation will default to null
            // if the cast is bad.
            set { _pb1 = value as ChildProperty1; }
        }
    }
