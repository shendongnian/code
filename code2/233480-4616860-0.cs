    public class ClassA
    {
        private Lazy<ClassB> _b = new Lazy<ClassB>(() => new ClassB());
    
        public ClassB B
        {
            get
            {
                return _b.Value;
            }
        }
    }
